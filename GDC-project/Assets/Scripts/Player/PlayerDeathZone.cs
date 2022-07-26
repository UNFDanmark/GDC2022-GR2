using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathZone : MonoBehaviour
{
    SceneHandler sceneHandler;

    private void Awake()
    {
        sceneHandler = FindObjectOfType<SceneHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sceneHandler.RestartScene();
        }
    }
}
