using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float time;
    public float firstDist;
    private float curTime;
    void Start()
    {
        time = (firstDist+2.5f) / speed;
        curTime = 0.0f;
        transform.position = GameManager.instance.cube.gameObject.transform.position + new Vector3(0, 0, firstDist);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= time)
        {
            //curTime = 0;
            /*if (isCorrect()) StartNewStage();
            else GameOver();*/

        }
        else
        {
            transform.position += (Camera.main.transform.position - transform.position).normalized * Time.deltaTime * speed;
        }
    }
}
