using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.text = "Score: " + Score.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
