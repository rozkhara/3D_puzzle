using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float timer;
    public bool rotationLock { get; private set; }
    public void RotToTarget(Quaternion target)
    {
        rotationLock = true;
        StartCoroutine(rotToTagetRoutine(target));
    }

    private IEnumerator rotToTagetRoutine(Quaternion target)
    {
        timer = 0f;
        Quaternion origin =  GameManager.instance.stage.cubes.rotation;
        while(timer<0.05f)
        {
            timer += Time.deltaTime;
            GameManager.instance.stage.cubes.rotation =  Quaternion.Lerp(origin, target, timer / 0.05f);
            yield return null;
        }
        GameManager.instance.stage.cubes.rotation = target;
        rotationLock = false;
    }
}
