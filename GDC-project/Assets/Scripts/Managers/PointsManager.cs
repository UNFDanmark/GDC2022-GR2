using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int highscore = 0;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI highscoreText;

    public static PointsManager instance;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(gameObject + "Is a Singleton ");
        }
        else
        {
            Debug.LogWarningFormat(gameObject, "Destroyed");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(scoreText == null || highscoreText == null)
        {
            FindTexts();
        }

        PointsManager.instance.scoreText.text = "Score: " + score;
        PointsManager.instance.highscoreText.text = "Highscore " + highscore;
    }

    void FindTexts()
    {
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        highscoreText = GameObject.FindWithTag("HighscoreText").GetComponent<TextMeshProUGUI>();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighscore()
    {
        return highscore;
    }

    public void SetScoreAsHighscore()
    {
        highscore = score;
        score = 0;
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }
}
