using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float timer;
    private float coolTime;
    private float curCoolTime = 0;
    private void Start()
    {
        coolTime = 1.0f / speed + 0.05f;
    }
    private void Update()
    {
        curCoolTime = Mathf.Max(curCoolTime - Time.deltaTime, 0);
    }
    public void Up()
    {
        if (curCoolTime != 0) return;
        curCoolTime = coolTime;
        timer = 0f;
        StartCoroutine(UpCoroutine());
    }

    IEnumerator UpCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.Rotate(Vector3.right * 90 * Time.deltaTime * speed, Space.World);
            yield return null;
        }
        GameManager.instance.stage.cubes.Rotate(Vector3.right * (90 - 90 * timer * speed), Space.World);
    }

    public void Down()
    {
        if (curCoolTime != 0) return;
        curCoolTime = coolTime;
        timer = 0f;
        StartCoroutine(DownCoroutine());
    }

    IEnumerator DownCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.Rotate(Vector3.left * 90 * Time.deltaTime * speed, Space.World);
            yield return null;
        }
        GameManager.instance.stage.cubes.Rotate(Vector3.left * (90 - 90 * timer * speed), Space.World);
    }

    public void Left()
    {

        if (curCoolTime != 0) return;
        curCoolTime = coolTime;
        timer = 0f;
        StartCoroutine(LeftCoroutine());
    }

    IEnumerator LeftCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.Rotate(Vector3.up * 90 * Time.deltaTime * speed, Space.World);
            yield return null;
        }
        GameManager.instance.stage.cubes.Rotate(Vector3.up * (90 - 90 * timer * speed), Space.World);
    }

    public void Right()
    {
        if (curCoolTime != 0) return;
        curCoolTime = coolTime;
        timer = 0f;
        StartCoroutine(RightCoroutine());
    }

    IEnumerator RightCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.Rotate(Vector3.down * 90 * Time.deltaTime * speed, Space.World);
            yield return null;
        }
        GameManager.instance.stage.cubes.Rotate(Vector3.down * (90 - 90 * timer * speed), Space.World);
    }



    public void Clock()
    {
        if (curCoolTime != 0) return;
        curCoolTime = coolTime;
        timer = 0f;
        StartCoroutine(ClockCoroutine());
    }

    IEnumerator ClockCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.Rotate(Vector3.back * 90 * Time.deltaTime * speed, Space.World);
            yield return null;
        }
        GameManager.instance.stage.cubes.Rotate(Vector3.back * (90 - 90 * timer * speed), Space.World);
    }

    public void CounterClock()
    {
        if (curCoolTime != 0) return;
        curCoolTime = coolTime;
        timer = 0f;
        StartCoroutine(CounterClockCoroutine());
    }

    IEnumerator CounterClockCoroutine()
    {
        while (timer * speed < 1f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.Rotate(Vector3.forward * 90 * Time.deltaTime * speed, Space.World);
            yield return null;
        }
        GameManager.instance.stage.cubes.Rotate(Vector3.forward * (90 - 90 * timer * speed), Space.World);
    }
}
