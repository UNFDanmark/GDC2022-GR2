using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHandler : MonoBehaviour
{
    //public float defaultGravity = -13f;
    public float relativeStarSpeed = -2f;

    void Start()
    {
        //Physics.gravity = new Vector3(0, defaultGravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetStarSpeed()
    {
        return relativeStarSpeed;
    }
}
