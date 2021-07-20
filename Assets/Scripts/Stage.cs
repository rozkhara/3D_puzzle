using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject[] group;
    public Transform cubes;

    void Start()
    {
        Spawn();
    }

    void Update()
    {

    }

    void Spawn()
    {
        var go = Instantiate(group[Random.Range(0, group.Length)]);
        go.transform.parent = cubes;
    }
}
