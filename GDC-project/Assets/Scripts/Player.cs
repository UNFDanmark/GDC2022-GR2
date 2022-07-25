using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float speed = 5f;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float xVelocity = speed * moveInput * Time.deltaTime;


        transform.Translate(new Vector3(xVelocity, 0, 0));
    }
}
