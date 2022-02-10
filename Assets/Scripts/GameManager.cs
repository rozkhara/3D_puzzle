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
    public int highscore;

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
        highscore = PlayerPrefs.GetInt("highscore");

        isFrozen = false;
        isGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FreezeAll();
        }
        Debug.Log(highscore);
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
