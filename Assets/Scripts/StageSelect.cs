using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void SelectEasy()
    {
        SceneManager.LoadScene("EasyScene");
    }

    public void SelectMedium()
    {
        SceneManager.LoadScene("MediumScene");
    }

    public void SelectHard()
    {
        SceneManager.LoadScene("HardScene");
    }

    public void ExitSelectScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
