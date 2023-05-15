using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreText : MonoBehaviour
{

    const string defaultString = "SCORE: ";
    public TextMeshProUGUI scoretext;
    
    public void setScore(int _score)
    {
        
        if(Score.score < 0)
        {
            Score.score = 0;
        }

        Score.score = _score;
        scoretext.text = "SCORE: " + Score.score;
    }
    public void increaseScore(int _score)
    {
        Score.score += _score;
        scoretext.text = "SCORE: " + Score.score;
    }

    public void resetScore()
    {
        Score.score = 0;
        scoretext.text = defaultString + Score.score;
    }
    public int getScore()
    {
        return Score.score;
    }
}
