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

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void ToSelectScene()
    {
        SceneManager.LoadScene("SelectScene");

    }

    public void InGameToMain()
    {
        GameManager.instance.isFrozen = false;
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "EasyScene")
        {
            if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_easy)
            {
                GameManager.instance.highscore_easy = GameManager.instance.stage.stageNum;
                PlayerPrefs.SetInt("highscoreeasy", GameManager.instance.highscore_easy);
                PlayerPrefs.Save();
            }

        }
        else if (SceneManager.GetActiveScene().name == "MediumScene")
        {
            if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_medium)
            {
                GameManager.instance.highscore_medium = GameManager.instance.stage.stageNum;
                PlayerPrefs.SetInt("highscoremedium", GameManager.instance.highscore_medium);
                PlayerPrefs.Save();
            }
        }
        else if (SceneManager.GetActiveScene().name == "HardScene")
        {
            if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_hard)
            {
                GameManager.instance.highscore_hard = GameManager.instance.stage.stageNum;
                PlayerPrefs.SetInt("highscorehard", GameManager.instance.highscore_hard);
                PlayerPrefs.Save();
            }
        }
        SceneManager.LoadScene("MainMenu");
    }

}
