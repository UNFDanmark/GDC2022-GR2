using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float speed = 5f;

    float xVelocity = 0f;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        xVelocity = speed * moveInput;

        xVelocity = Mathf.Clamp(xVelocity, -maxSpeed, maxSpeed);

        transform.Translate(new Vector3(xVelocity, 0, 0));
    }
}
