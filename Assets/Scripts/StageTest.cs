using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTest : MonoBehaviour
{
    List<int> cubeList = new List<int>();

    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private GameObject[] group;
    [SerializeField]
    private Transform[] spawnPoint;
    public Transform cubes;
    public bool[,] data = new bool[,] { { false, false, false }, { false, false, false }, { false, false, false } };
    Vector3[] positions = new Vector3[6] { new Vector3(0, 0, -5), new Vector3(0, 5, 0), new Vector3(0, 0, 5), new Vector3(0, -5, 0), new Vector3(5, 0, 0), new Vector3(-5, 0, 0) };
    Vector3[] directions = new Vector3[6] { new Vector3(0, 0, 1), new Vector3(0, -1, 0), new Vector3(0, 0, -1), new Vector3(0, 1, 0), new Vector3(-1, 0, 0), new Vector3(1, 0, 0) };
    public int stageNum = 0;
    void Start()
    {
        StartCoroutine(StartNewStage());
    }

    void Update()
    {

    }
    public IEnumerator StartNewStage()
    {
        Debug.Log("Stage" + ++stageNum + "!");
        DestroyCubes();
        GameManager.instance.plane.BasicSetting();
        GameManager.instance.plane.isLoading = true;
        //Debug.Log("CHILD:"+GameManager.instance.cube.transform.childCount);
        yield return new WaitForSeconds(0.1f);
        //Debug.Log("CHILDAFTER:" + GameManager.instance.cube.transform.childCount);
        GameManager.instance.plane.isLoading = false;
        for (int i = 0; i < 27; i++)
        {
            cubeList.Add(i);
        }
        int cnt = Random.Range(1, 28);
        for (int i = 0; i < cnt; i++)
        {
            Spawn();
        }
        DeterminePlane();
        ConstructPlane();
    }
    void Spawn()
    {
        /*
        var go = Instantiate(group[Random.Range(0, group.Length)]);
        go.transform.parent = cubes;
        */


        //int ran = Random.Range(0, cubeList.Count);
        int ran = SampleGaussian(0, cubeList.Count);
        var go = Instantiate(cube, spawnPoint[cubeList[ran]].transform.position, spawnPoint[cubeList[ran]].rotation);
        go.transform.parent = cubes;
        cubeList.RemoveAt(ran);

    }

    void DeterminePlane()
    {
        for (int i = 0; i < 9; i++)
        {
            data[i / 3, i % 3] = false;
        }
        RaycastHit hit;
        int index = Random.Range(0, 6);
        //index = 0;
        bool isRay;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 curPos = positions[index] + DetermineLoc(j, i, index);
                isRay = Physics.Raycast(curPos, directions[index], out hit, 8.0f);//, ~(1<<6));
                if (isRay)
                {
                    //Debug.Log(hit.distance + "\t" + hit.collider.transform.position);
                    data[i, j] = true;
                }
            }
        }
        Debug.Log(index + "\t" + data[0, 0] + " " + data[0, 1] + " " + data[0, 2] + "\t" + data[1, 0] + " " + data[1, 1] + " " + data[1, 2] + "\t" + data[2, 0] + " " + data[2, 1] + " " + data[2, 2] + " ");
    }
    private Vector3 DetermineLoc(int i, int j, int index)
    {
        switch (index)
        {
            case 0:
                return new Vector3(i - 1, 1 - j, 0) * 2;
            case 1:
                return new Vector3(i - 1, 0, 1 - j) * 2;
            case 2:
                return new Vector3(1 - i, 1 - j, 0) * 2;
            case 3:
                return new Vector3(1 - i, 0, 1 - j) * 2;
            case 4:
                return new Vector3(0, 1 - j, i - 1) * 2;
            case 5:
                return new Vector3(0, 1 - j, 1 - i) * 2;
            default:
                Debug.Log("indexError");
                return new Vector3(-100, -100, -100);

        }
    }

    private void ConstructPlane()
    {
        Vector3[] rayLoc = new Vector3[6];
        Vector3[] rayDir = new Vector3[6];
        int rot = Random.Range(0, 4);
        // rot = 0;
        GameManager.instance.plane.collection.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90.0f * rot));
        Debug.Log(rot);
        for (int i = 0; i < 9; i++)
        {
            GameManager.instance.plane.cubes[i].SetActive(!GameManager.instance.stage.data[i / 3, i % 3]);
        }

    }
    private void DestroyCubes()
    {
        for (int i = 0; i < GameManager.instance.cube.transform.childCount; i++)
        {
            Destroy(GameManager.instance.cube.transform.GetChild(i).gameObject);
        }
        cubeList.Clear();
    }

    public static int SampleGaussian(int min, int max)
    {

        double mean = (min + max) / 2;
        double sigma = (max - mean) / 3;

        System.Random random = new System.Random();
        // The method requires sampling from a uniform random of (0,1]
        // but Random.NextDouble() returns a sample of [0,1).
        double x1 = 1 - random.NextDouble();
        double x2 = 1 - random.NextDouble();

        double y1 = System.Math.Sqrt(-2.0 * System.Math.Log(x1)) * System.Math.Cos(2.0 * System.Math.PI * x2);
        var returnVal = y1 * sigma + mean;
        returnVal = (int)System.Math.Round(returnVal, System.MidpointRounding.AwayFromZero);
        return (int)returnVal;
    }


}
