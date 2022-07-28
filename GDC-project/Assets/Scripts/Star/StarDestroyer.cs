using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyer : MonoBehaviour
{
    Camera cam;
    Transform camTransform;

    private void Awake()
    {
        cam = Camera.main;
        camTransform = cam.transform;
    }

    private void Update()
    {
        if(transform.position.y < camTransform.position.y - cam.orthographicSize - 4)
        {
            float newY = camTransform.position.y - cam.orthographicSize - 4;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StarTop" || other.tag == "StarBottom")
        {
            other.transform.parent.gameObject.GetComponent<Star>().DestroyStar(false);
        }
    }
}
