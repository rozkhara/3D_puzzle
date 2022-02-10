using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public void ToInitialStage()
    {
        GameManager.instance.plane.Multiplier = 1 / Mathf.Pow(2, 0.01f);
        Time.timeScale = 1f;
        GameManager.instance.stage.stageNum = 0;
        StartCoroutine(GameOverResetCoroutine());
        StartCoroutine(GameManager.instance.stage.StartNewStage());
    }

    private IEnumerator GameOverResetCoroutine()
    {
        yield return new WaitForEndOfFrame();
        GameManager.instance.isGameOver = false;
    }
}
