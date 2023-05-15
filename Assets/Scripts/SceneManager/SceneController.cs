using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    // Start is called before the first frame update
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    public static void Restart()
    {
        LoadScene("GamePlay");
    }

    public static void Next()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void End()
    {
        LoadScene("GameOver");
    }

    public static void Return()
    {
        LoadScene(0);
    }
}
