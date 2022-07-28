using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    //public float speed; 

    //Rigidbody rb;
    public GameObject deathEffect;

    /*void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.down * speed;
    }*/

    public void DestroyStar(bool playEffect)
    {
        if (deathEffect != null && playEffect) Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
