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
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        else
        {
            Time.timeScale = 0;
            return;
        }
    }


}
