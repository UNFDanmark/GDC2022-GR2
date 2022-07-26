using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenPointsHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public List<ParticleSystem> particleSystems;
    public HighscoreSaver highscoreSaver;

    //PointsManager pointsManager;

    void Awake()
    {
        highscoreSaver = FindObjectOfType<HighscoreSaver>();
        //pointsManager = FindObjectOfType<PointsManager>();
    }

    void Start()
    {
        /*if (pointsManager == null)
        {
            Debug.LogError("No PointsManager found. Try launching the game from the start- or game screen");
            return;
        }*/

        /*int score = pointsManager.GetScore();
        int highscore = pointsManager.GetHighscore();*/

        int score = highscoreSaver.score;
        int highscore = highscoreSaver.highscore;
        
        Destroy(highscoreSaver);
        highscoreSaver = null;

        scoreText.text = "Score: " + score;

        if (score > highscore)
        {
            highscoreText.text = "Old Highscore: " + highscore;
        }
        else
        {
            highscoreText.text = "Highscore: " + highscore;
        }

        if(score > highscore)
        {
            foreach(ParticleSystem p in particleSystems)
            {
                p.Play();
            }

            PlayerPrefs.SetInt("Highscore", score);
            //pointsManager.SetScoreAsHighscore();
        }

        //pointsManager.ResetScore();
    }
}
