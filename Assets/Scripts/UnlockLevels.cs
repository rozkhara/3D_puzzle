using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    int highscore_medium, highscore_easy;
    GameObject medium, hard;

    public static bool isMediumOpened;
    public static bool isHardOpened;

    private void Awake()
    {
        medium = GameObject.Find("Medium");
        hard = GameObject.Find("Hard");

        isMediumOpened = false;
        isHardOpened = false;

        if (PlayerPrefs.HasKey("highscoreeasy"))
        {
            highscore_easy = PlayerPrefs.GetInt("highscoreeasy");
        }
        if (PlayerPrefs.HasKey("highscoremedium"))
        {
            highscore_medium = PlayerPrefs.GetInt("highscoremedium");
        }
    }
    private void Start()
    {
        if (highscore_easy >= 50)
        {
            medium.GetComponent<Image>().color = new Color(238 / 255f, 242 / 255f, 121 / 255f);
        }
        else
        {
            medium.GetComponent<Image>().color = new Color(123 / 255f, 125 / 255f, 65 / 255f);
        }
        if (highscore_medium >= 50)
        {
            hard.GetComponent<Image>().color = new Color(238 / 255f, 242 / 255f, 121 / 255f);
        }
        else
        {
            hard.GetComponent<Image>().color = new Color(123 / 255f, 125 / 255f, 65 / 255f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            medium.GetComponent<Image>().color = new Color(238 / 255f, 242 / 255f, 121 / 255f);
            isMediumOpened = true;
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            hard.GetComponent<Image>().color = new Color(238 / 255f, 242 / 255f, 121 / 255f);
            isHardOpened = true;
        }
    }
}
