using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float timer;

    public void Up()
    {
        timer = 0f;
        StartCoroutine(UpCoroutine());
    }

    IEnumerator UpCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(90 * Time.deltaTime * speed, 0, 0);
            yield return null;
        }
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(90 - 90 * timer * speed, 0, 0);
    }

    public void Down()
    {
        timer = 0f;
        StartCoroutine(DownCoroutine());
    }

    IEnumerator DownCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(-90 * Time.deltaTime * speed, 0, 0);
            yield return null;
        }
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(90 * timer * speed - 90, 0, 0);
    }

    public void Left()
    {
        timer = 0f;
        StartCoroutine(LeftCoroutine());
    }

    IEnumerator LeftCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 90 * Time.deltaTime * speed, 0);
            yield return null;
        }
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 90 - 90 * timer * speed, 0);
    }

    public void Right()
    {
        timer = 0f;
        StartCoroutine(RightCoroutine());
    }

    IEnumerator RightCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, -90 * Time.deltaTime * speed, 0);
            yield return null;
        }
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 90 * timer * speed - 90, 0);
    }



    public void Clock()
    {
        timer = 0f;
        StartCoroutine(ClockCoroutine());
    }

    IEnumerator ClockCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 0, -90 * Time.deltaTime * speed);
            yield return null;
        }
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 0, 90 * timer * speed - 90);
    }

    public void CounterClock()
    {
        timer = 0f;
        StartCoroutine(CounterClockCoroutine());
    }

    IEnumerator CounterClockCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 0, 90 * Time.deltaTime * speed);
            yield return null;
        }
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 0, 90 - 90 * timer * speed);
    }
}
