using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHighscore : MonoBehaviour
{
    
    public Text highScore_easy;
    public Text highScore_medium;
    public Text highScore_hard;

    void Update()
    {
        highScore_easy.text = "EASY : "+ GameManager.instance.highscore_easy;
        highScore_medium.text = "MEDIUM : "+ GameManager.instance.highscore_medium;
        highScore_hard.text = "HARD : "+ GameManager.instance.highscore_hard;
    }
}
