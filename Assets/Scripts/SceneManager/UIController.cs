using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        gameManager.startGame();
        SceneController.LoadScene(1);
    }

    public void Restart()
    {
        SceneController.Restart();
    }

    public void End()
    {
        SceneController.End();
    }
    public void Return()
    {
        gameManager.endGame();
        SceneController.Return();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneController.LoadScene(sceneIndex);
    }
}
