using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReplacer : MonoBehaviour
{
    public int indexToLoad = 1;
    SceneHandler sceneHandler;

    void Awake()
    {
        sceneHandler = FindObjectOfType<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sceneHandler.LoadSceneIndex(indexToLoad);
        }
    }
}
