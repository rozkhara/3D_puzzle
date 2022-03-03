using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    int highscore_medium, highscore_easy;
    public void SelectEasy()
    {
        SceneManager.LoadScene("EasyScene");
    }

    public void SelectMedium()
    {
        if (PlayerPrefs.HasKey("highscoreeasy"))
        {
            highscore_easy = PlayerPrefs.GetInt("highscoreeasy");
            if (highscore_easy >= 50)
            {
                SceneManager.LoadScene("MediumScene");
            }
        }
    }

    public void SelectHard()
    {
        if (PlayerPrefs.HasKey("highscoremedium"))
        {
            highscore_medium = PlayerPrefs.GetInt("highscoremedium");
            if (highscore_medium >= 50)
            {
                SceneManager.LoadScene("HardScene");
            }
        }
    }

    public void ExitSelectScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
