using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float defaultGravity = -13f;
    public float startJumpForce = 600f;
    public float jumpModifier = 1.25f;
    public float startAttackSpeed = 5f;
    public float attackGravityMultiplier = 3f;
    public float weakJump = 4f;
    public float starBottomBounceback = -5f;
    Vector3 previousVel;
    Vector3 previousPos;
    float screenHeight;
    float screenWidth;

    bool firstJump = true;
    bool starHit = false;
    bool isAttacking = false;

    PointsManager pm;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, defaultGravity, 0);
        rb = GetComponent<Rigidbody>();
        pm = FindObjectOfType<PointsManager>();

        screenHeight = 2f * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        //Save current speed and position
        previousVel = rb.velocity;
        previousPos = transform.position;

        //Move and attack
        MoveHandler();
        AttackHandler();
    }

    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float xVelocity = speed * moveInput * Time.deltaTime;

        //problem her (noget med velocity skal til x og y i stedet for 0). Problem fordi vi luge ny fortæller den ikke at bevæge sig i starten og tygndekragt holdeer den nede??
       rb.velocity = new Vector3(xVelocity, 0, 0);

        float xPos = Mathf.Clamp(transform.position.x, -screenWidth/2, screenWidth/2);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        bool wantsToJump = Input.GetButtonDown("Jump");

        if (firstJump && wantsToJump && !starHit)
        {
            rb.AddForce(Vector3.up * startJumpForce);
            firstJump = false;
        }
    }

    void AttackHandler()
    {
        if (Input.GetKeyDown("s"))
        {
            rb.velocity = new Vector3(rb.velocity.x, -startAttackSpeed, rb.velocity.z); //Sets the vertical speed to attack speed
            isAttacking = true;
            Physics.gravity = new Vector3(0, attackGravityMultiplier * defaultGravity, 0);
        }
        else if (Input.GetKeyUp("s"))
        {
            CancelAttack();
        }
    }

    void CancelAttack()
    {
        Physics.gravity = new Vector3(0, defaultGravity, 0);
            isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StarTop")
        {
            if (isAttacking)
            {
                transform.position = previousPos;
                rb.velocity = new Vector3(previousVel.x, Mathf.Max(-previousVel.y * jumpModifier, weakJump), previousVel.z);
                Destroy(other.transform.parent.gameObject);
                pm.IncreaseScore(1);
            }
            else
            {
                transform.position = previousPos;
                rb.velocity = new Vector3(previousVel.x, weakJump, previousVel.z);
            }
            CancelAttack();
            starHit = true;
        }
        else if (other.gameObject.tag == "StarBottom")
        {
            rb.velocity = new Vector3(rb.velocity.x, starBottomBounceback, rb.velocity.z);
            CancelAttack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            firstJump = true;
        }
    }
}