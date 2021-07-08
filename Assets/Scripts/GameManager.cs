using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<int> cubeList = new List<int>();

    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private Transform[] spawnPoint;

    void Start()
    {
        for (int i = 0; i < 27; i++)
        {
            cubeList.Add(i);
        }
        int cnt = Random.Range(1, 28);
        for (int i = 0; i < cnt; i++)
        {
            Spawn();
        }
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        int ran = Random.Range(0, cubeList.Count);
        Instantiate(cube, spawnPoint[cubeList[ran]].position, spawnPoint[cubeList[ran]].rotation);
        cubeList.RemoveAt(ran);
    }
}
