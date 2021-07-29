using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageTest : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private Transform[] spawnPoint;
    public Transform cubes;
    List<int> cubeList = new List<int>();
    private bool[] array = new bool[27];
    void Start()
    {
        cubeList.Add(Random.Range(0, 27));
        int cnt = Random.Range(1, 28);
        for (int i = 0; i < 27; i++)
        {
            array[i] = false;
        }
        for (int i = 0; i < cnt; i++)
        {
            Spawn(i);
        }
    }

    void Update()
    {

    }

    void Spawn(int i)
    {
        if (i == 0)
        {
            int k = cubeList[0];
            var go = Instantiate(cube, spawnPoint[k].transform.position, spawnPoint[k].transform.rotation);
            go.transform.parent = cubes;
            array[k] = true;
            #region --add to list--
            if (k + 1 < 27 && !array[k + 1])
            {
                cubeList.Add(k + 1);
                //array[k + 1] = true;
            }
            if (k - 1 > 0 && !array[k - 1])
            {
                cubeList.Add(k - 1);
                //array[k - 1] = true;
            }
            if (k + 3 < 27 && !array[k + 3])
            {
                cubeList.Add(k + 3);
                //array[k + 3] = true;
            }
            if (k - 3 > 0 && !array[k - 3])
            {
                cubeList.Add(k - 3);
                //array[k - 3] = true;
            }
            if (k + 9 < 27 && !array[k + 9])
            {
                cubeList.Add(k + 9);
                //array[k + 9] = true;
            }
            if (k - 9 > 0 && !array[k - 9])
            {
                cubeList.Add(k - 9);
                //array[k - 9] = true;
            }
            #endregion
            cubeList.RemoveAt(0);
            cubeList = cubeList.Distinct().ToList();
        }
        else
        {
            int k = cubeList[Random.Range(0, cubeList.Count)];
            var go = Instantiate(cube, spawnPoint[k].transform.position, spawnPoint[k].transform.rotation);
            go.transform.parent = cubes;
            array[k] = true;
            #region --add to list--
            if (k + 1 < 27 && !array[k + 1])
            {
                cubeList.Add(k + 1);
                //array[k + 1] = true;
            }
            if (k - 1 > 0 && !array[k - 1])
            {
                cubeList.Add(k - 1);
                //array[k - 1] = true;
            }
            if (k + 3 < 27 && !array[k + 3])
            {
                cubeList.Add(k + 3);
                //array[k + 3] = true;
            }
            if (k - 3 > 0 && !array[k - 3])
            {
                cubeList.Add(k - 3);
                //array[k - 3] = true;
            }
            if (k + 9 < 27 && !array[k + 9])
            {
                cubeList.Add(k + 9);
                //array[k + 9] = true;
            }
            if (k - 9 > 0 && !array[k - 9])
            {
                cubeList.Add(k - 9);
                //array[k - 9] = true;
            }
            #endregion
            cubeList.RemoveAt(k);
            cubeList = cubeList.Distinct().ToList();
        }
    }
    

}