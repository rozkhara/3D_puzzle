using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public void Up()
    {
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(90, 0, 0);
        print("HI");
    }

    public void Down()
    {
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(-90, 0, 0);
    }

    public void Left()
    {
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 90, 0);
    }

    public void Right()
    {
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, -90, 0);
    }

    public void Clock()
    {
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 0, -90);
    }

    public void CounterClock()
    {
        GameManager.instance.stage.cubes.transform.rotation *= Quaternion.Euler(0, 0, 90);
    }
}
