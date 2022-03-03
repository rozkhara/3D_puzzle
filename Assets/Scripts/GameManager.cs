using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CubeController cube;
    public Stage stage;
    public Plane plane;
    public Swipe swipe;

    public bool isFrozen;
    public bool isGameOver;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    private GameObject instPausePanel;
    public int highscore_easy;
    public int highscore_medium;
    public int highscore_hard;
    public int stageIdx;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (PlayerPrefs.HasKey("highscoreeasy"))
        {
            highscore_easy = PlayerPrefs.GetInt("highscoreeasy");
        }
        else
        {
            highscore_easy = 0;
        }
        if (PlayerPrefs.HasKey("highscoremedium"))
        {
            highscore_medium = PlayerPrefs.GetInt("highscoremedium");
        }
        else
        {
            highscore_medium = 0;
        }
        if (PlayerPrefs.HasKey("highscorehard"))
        {
            highscore_hard = PlayerPrefs.GetInt("highscorehard");
        }
        else
        {
            highscore_hard = 0;
        }


        isFrozen = false;
        isGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FreezeAll();
        }
        // Debug.Log(highscore);
    }

    public void FreezeAll()
    {
        if (isFrozen)
        {
            Destroy(instPausePanel);
            Time.timeScale = 1f;
            isFrozen = false;
            return;
        }
        else
        {
            instPausePanel = Instantiate(pausePanel, GameObject.Find("Canvas").transform);
            Time.timeScale = 0f;
            isFrozen = true;
            return;
        }
    }


}
