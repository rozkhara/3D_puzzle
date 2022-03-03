using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text highScore;

    private void Update()
    {
        highScore.text = "HIGH SCORE : " + GameManager.instance.highscore;
    }
}
