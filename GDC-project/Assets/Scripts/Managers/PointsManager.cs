using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    int score = 0;
    int highscore = 0;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI highscoreText;

    private void Awake()
    {
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        highscoreText = GameObject.FindWithTag("HighscoreText").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        highscoreText.text = "Highscore " + highscore;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighscore()
    {
        return highscore;
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }

    public void HandleDeath()
    {
        if (score > highscore)
        {
            highscore = score;
        }
    }
}
