using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
