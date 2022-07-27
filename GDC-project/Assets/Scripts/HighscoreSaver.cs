using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreSaver : MonoBehaviour
{
    public int score;
    public int highscore;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
