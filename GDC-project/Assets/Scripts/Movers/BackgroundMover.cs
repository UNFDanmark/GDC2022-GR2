using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;
    GameObject bottomPlane;
    GameObject topPlane;

    public float planeScale;
    float camHeight;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        bottomPlane = bg1;
        topPlane = bg2;
    }

    void Update()
    {
        if(cam.transform.position.y - camHeight - 2 > bottomPlane.transform.position.y + 10f * planeScale)
        {
            float newYPos = topPlane.transform.position.y + 10f * planeScale;
            bottomPlane.transform.position = new Vector3(transform.position.x, newYPos, 2); //doesnt work when using transform.positio.z as 3rd parameter???

            GameObject temp = topPlane;
            topPlane = bottomPlane;
            bottomPlane = temp;
        }
    }
}
