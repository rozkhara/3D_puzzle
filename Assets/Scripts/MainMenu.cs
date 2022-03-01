using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    void Update()
    {
        StartGame();
    }

    void StartGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.highscore == -1)
            {
                SceneManager.LoadScene("TutorialScene");
            }
            else
            {
                SceneManager.LoadScene(sceneToLoad);
                //난이도 선택
            }
        }
    }
}
