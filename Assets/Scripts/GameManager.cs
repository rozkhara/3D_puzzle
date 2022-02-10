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

        isFrozen = false;
        isGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FreezeAll();
        }
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
