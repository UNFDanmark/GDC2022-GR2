using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float defaultGravity = -13f;
    public float startJumpForce = 500f;
    public float moveSpeed = 5f;
    public float jumpModifier = 1f;
    public float startAttackSpeed = 1f;
    public float attackGravityMultiplier = 3f;
    public float weakJump = 1f;

    Vector3 previousVel;
    Vector3 previousPos;

    bool firstJump = true;
    bool starHit = false;
    public bool isAttacking = false;

    //if hit from above with attack, jump high, destroy star
    //if hit from above without attack lil jump (enough to try again), dont destroy star
    //if hit from below, fall down (die?)
    //the faster the attack/dash, the more powerful the jump boost

    Rigidbody rb;

    float lastSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, defaultGravity, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) print(rb.velocity.y - lastSpeed);
        //Save current speed and position
        previousVel = rb.velocity;
        previousPos = transform.position;

        //Move and attack
        MoveHandler();
        AttackHandler();

        lastSpeed = rb.velocity.y;
    }

    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        bool wantsToJump = Input.GetButtonDown("Jump");

        if (firstJump && wantsToJump && !starHit)
        {
            Debug.Log("Jump dangit");
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
            Physics.gravity = new Vector3(0, defaultGravity, 0);
            isAttacking = false;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StarTop")
        {
            if(isAttacking)
            {
                print("attack!");
                transform.position = previousPos;
                rb.velocity = new Vector3(previousVel.x, Mathf.Max(-previousVel.y * jumpModifier, weakJump), previousVel.z);
                Destroy(other.transform.parent.gameObject);
            }
            else
            {
                transform.position = previousPos;
                rb.velocity = new Vector3(previousVel.x, weakJump, previousVel.z);
            }
            isAttacking=false;
            starHit = true;
        }
        else if (other.gameObject.tag == "StarBottom")
        {
            Debug.Log("U suck");
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
