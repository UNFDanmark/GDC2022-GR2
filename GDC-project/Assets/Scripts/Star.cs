using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed; 

    Rigidbody rb;
    public GameObject deathEffect;
    private PhysicsHandler ph;

    private void Awake()
    {
        ph = FindObjectOfType<PhysicsHandler>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = ph.GetStarSpeed();

        rb.velocity = Vector3.down * speed;
    }

    private void Update()
    {
        speed = ph.GetStarSpeed();
        rb.velocity = new Vector3(0, speed, 0);
    }

    private void OnDestroy()
    {
        if(deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
