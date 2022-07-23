using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 1f;
    public float HKForce = 1f;

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
        MoveHandler();
        AttackHandler();
    }

    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

    }

    void AttackHandler()
    {

    }
}
