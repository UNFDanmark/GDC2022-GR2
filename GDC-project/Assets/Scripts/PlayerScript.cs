using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float startJumpForce = 500f;
    public float moveSpeed = 5f;
    public float jumpModifier = 1f;
    //public float HKForce = 1f;
    public float startAttackSpeed = 1f;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
        else if (Input.GetKeyUp("s"))
        {
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
                rb.velocity = new Vector3(previousVel.x, -previousVel.y * jumpModifier, previousVel.z);
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
