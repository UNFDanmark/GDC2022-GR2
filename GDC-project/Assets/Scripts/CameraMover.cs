using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    Transform target = null;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}
