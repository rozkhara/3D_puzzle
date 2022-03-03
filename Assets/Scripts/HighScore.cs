using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text highScore;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "EasyScene")
        {
            highScore.text = "HIGH SCORE : " + GameManager.instance.highscore_easy;
        }
        else if (SceneManager.GetActiveScene().name == "MediumScene")
        {
            highScore.text = "HIGH SCORE : " + GameManager.instance.highscore_medium;
        }
        else if (SceneManager.GetActiveScene().name == "HardScene")
        {
            highScore.text = "HIGH SCORE : " + GameManager.instance.highscore_hard;
        }
    }
        
}
