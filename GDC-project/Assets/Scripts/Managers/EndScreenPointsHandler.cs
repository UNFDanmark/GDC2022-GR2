using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenPointsHandler : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI highscoreText;

    PointsManager pointsHandler;

    void Awake()
    {
        pointsHandler = FindObjectOfType<PointsManager>();
    }

    void Start()
    {
        int score = pointsHandler.GetScore();
        int highscore = pointsHandler.GetHighscore();



        if(score > highscore)
        {
            
        }
    }
}
