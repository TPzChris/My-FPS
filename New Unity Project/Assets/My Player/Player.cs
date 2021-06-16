using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public int GetScore()
    {
        return this.score;
    }

    public void SetText(Text scoreText)
    {
        this.scoreText = scoreText;
    }

    public void ScoreInc()
    {
        this.score += 10;
        scoreText.text = "Score: " + this.score;
    }
}
