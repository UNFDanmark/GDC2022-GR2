using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float startJumpForce = 500f;
    public float moveSpeed = 5f;
    public float jumpModifier = 1f;
    public float HKForce = 1f;

    Vector3 previousVel;
    Vector3 previousPos;

    bool firstJump = true;

    //if hit from above with attack, jump high
    //if hit from above without attack lil jump (enough to try again)
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
        previousVel = rb.velocity;
        previousPos = transform.position;
        MoveHandler();
        AttackHandler();
    }

    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        if(firstJump && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump dangit");
            rb.AddForce(Vector3.up * startJumpForce);
            firstJump = false;
        }
    }

    void AttackHandler()
    {

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            firstJump = true;
        }
        else if (other.gameObject.tag == "StarTop")
        {
            Debug.Log("Jump from star!");
            transform.position = previousPos;
            rb.velocity = new Vector3(previousVel.x, -previousVel.y * jumpModifier, previousVel.z);
            Destroy(other.transform.parent.gameObject);
        }
        else if (other.gameObject.tag == "StarBottom")
        {
            Debug.Log("U suck");
        }
    }
}
