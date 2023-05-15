using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreText scoreText;
    public UIController uiController;
    public ExitScript exit;
    private int scoreM;
    private bool isGameEnded;

    void Start()
    {
        scoreM = 0;
        isGameEnded = false;
    }
    public void updateScore(int _score)
    {
        scoreM += _score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        isGameEnded = false;
    }

    public void endGame()
    {
        isGameEnded = true;
        uiController.End();
    }
    public bool getGameState()
    {
        return isGameEnded;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
