using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CubeController cube;
    public Stage stage;
    public Plane plane;
    public bool isFreeze;
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
        if (isFreeze)
        {
            Destroy(instPausePanel);
            Time.timeScale = 1;
            isFreeze = false;
            return;
        }
        else
        {
            instPausePanel = Instantiate(pausePanel, GameObject.Find("Canvas").transform);
            Time.timeScale = 0;
            isFreeze = true;
            return;
        }
    }


}
