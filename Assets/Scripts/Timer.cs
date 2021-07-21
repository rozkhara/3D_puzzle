using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    [SerializeField]
    private float timer;

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            timerText.text = string.Format("{0:N2}", timer);
        }
    }
}
