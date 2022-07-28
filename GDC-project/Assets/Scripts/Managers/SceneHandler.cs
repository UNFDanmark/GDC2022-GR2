using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public bool restartOnReturn = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && restartOnReturn)
        {
            RestartScene();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
