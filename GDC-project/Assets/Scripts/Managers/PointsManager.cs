using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int highscore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    public static PointsManager objectInstance;

    private void Awake()
    {
        /*if (objectInstance == null) {
            objectInstance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(gameObject + "Is a Singleton ");
        }
        else
        {
            Debug.LogWarningFormat(gameObject, "Destroyed");
            Destroy(gameObject);
        }*/

        highscore = PlayerPrefs.GetInt("Highscore");
    }

    private void Update()
    {
        if(scoreText == null || highscoreText == null)
        {
            FindTexts();
        }

        if (scoreText != null && highscoreText != null)
        {
            scoreText.text = "Score: " + score;
            highscoreText.text = "Highscore " + highscore;
        }
    }

    public void SetTextsAsNull()
    {
        scoreText = null;
        highscoreText = null;
    }

    void FindTexts()
    {
        GameObject s = GameObject.FindWithTag("ScoreText");
        GameObject hs = GameObject.FindWithTag("HighscoreText");

        if (s == null || hs == null) return;

        scoreText = s.GetComponent<TextMeshProUGUI>();
        highscoreText = hs.GetComponent<TextMeshProUGUI>();
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
        PlayerPrefs.SetInt("Highscore", highscore);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }
}
