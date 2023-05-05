using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score, highScore;

    public TextMeshProUGUI scoreText, scoreNumber;

    public void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", score);

        highScore = PlayerPrefs.GetInt("highscore");

        scoreNumber.text = "" + highScore;
        scoreText.text = "High Score";
    }

    public void ResetScore()
    {
        score = 0;

        scoreNumber.text = "" + score;
        scoreText.text = "Score";
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;

        scoreNumber.text = "" + score;
    }
}

