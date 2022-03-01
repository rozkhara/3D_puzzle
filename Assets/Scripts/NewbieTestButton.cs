using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewbieTestButton : MonoBehaviour
{
    void NewbieTest()
    {
        if (GameManager.instance.highscore == -1)
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            //난이도 선택
        }
    }
}
