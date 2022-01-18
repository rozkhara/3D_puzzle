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
