using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenPointsHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public List<ParticleSystem> particleSystems;


    PointsManager pointsManager;

    void Awake()
    {
        pointsManager = FindObjectOfType<PointsManager>();
    }

    void Start()
    {
        if (pointsManager == null)
        {
            Debug.LogError("No PointsManager found. Try launching the game from the start- or game screen");
            return;
        }

        int score = pointsManager.GetScore();
        int highscore = pointsManager.GetHighscore();

        scoreText.text = "Score: " + score;

        if (score > highscore)
        {
            highscoreText.text = "New Highscore: " + highscore;
        }
        else
        {
            highscoreText.text = "Old Highscore: " + highscore;
        }

        if(score > highscore)
        {
            foreach(ParticleSystem p in particleSystems)
            {
                p.Play();
            }

            pointsManager.SetScoreAsHighscore();
        }
    }
}
