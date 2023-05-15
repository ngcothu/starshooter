using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    [SerializeField]
    GameObject exitPanel;
    private bool exit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!exit)
            {
                exit = true;
                GeneralData.onOtherTasks = true;
                exitPanel.SetActive(true);
            }
            else
            {
                exit = false;
                GeneralData.onOtherTasks = false;
                exitPanel.SetActive(false);
            }
        }
    }


    public void button_exit()
    {
        Application.Quit();
    }
    public void onUserClickYes()
    {
        Application.Quit();
    }

    public void onUserClickNo()
    {
        GeneralData.onOtherTasks = false;
        exitPanel.SetActive(false);
    }

    public void onUserClickStart()
    {
        SceneManager.LoadScene(1);//load game scene
    }
}
