using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }
}
