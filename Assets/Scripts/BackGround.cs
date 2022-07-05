using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    private float curTime = 0f;
    private float coolTime = 0.2f;

    private List<Vector3> spawnPoints = new List<Vector3>();

    private void Start()
    {
        SetPosList(spawnPoints);
    }

    private void Update()
    {
        if (curTime >= coolTime)
        {
            Instantiate(cubePrefab, spawnPoints[Random.Range(0, 25)], Quaternion.identity);
            curTime = 0f;
        }
        curTime += Time.deltaTime;
    }

    private void SetPosList(List<Vector3> spawnPoints)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                spawnPoints.Add(new Vector3(-10 + i * 5, 20f, j * 5));
            }
        }
    }
}
