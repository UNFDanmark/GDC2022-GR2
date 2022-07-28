using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClusterMover : MonoBehaviour
{
    public float speed; 

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.down * speed;
    }
}
