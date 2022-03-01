using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    List<int> cubeList = new List<int>();
    public List<Vector3> cubePosList = new List<Vector3>();
    public List<Vector3> spawnPoints = new List<Vector3>();

    [SerializeField]
    private GameObject cube;
    public Transform cubes;
    public bool[,] data;
    Vector3[] positions = new Vector3[6] {
        new Vector3(0, 0, -5), new Vector3(0, 5, 0),
        new Vector3(0, 0, 5), new Vector3(0, -5, 0),
        new Vector3(5, 0, 0), new Vector3(-5, 0, 0)
    };
    Vector3[] directions = new Vector3[6] {
        new Vector3(0, 0, 2), new Vector3(0, -2, 0),
        new Vector3(0, 0, -2), new Vector3(0, 2, 0),
        new Vector3(-2, 0, 0), new Vector3(2, 0, 0)
    };
    public int stageNum = 0;

    private int cubeCnt;

    private int stageIdx;

    [SerializeField]
    Text stageText;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (var cubePos in cubePosList)
        {
            Gizmos.DrawWireCube(cubePos, new Vector3(2f, 2f, 2f));
        }
    }
    void Start()
    {
        stageIdx = GameManager.instance.stageIdx;
        data = new bool[stageIdx, stageIdx];
        cubeCnt = (int)Mathf.Pow(stageIdx, 3);
        SetPosList(spawnPoints);
        //spawnPoints =  GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        // System.Array.Copy(GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>(), 1, spawnPoints, 0, 27);

        StartCoroutine(StartNewStage());
    }

    void Update()
    {
    }

    private void SetPosList(List<Vector3> spawnPoints)
    {
        for (int i = 0; i < stageIdx; i++)
        {
            for (int j = 0; j < stageIdx; j++)
            {
                for (int k = 0; k < stageIdx; k++)
                {
                    spawnPoints.Add(new Vector3(-stageIdx + 1 + i * 2, -stageIdx + 1 + j * 2, -stageIdx + 1 + k * 2));
                }
            }
        }
    }

    public IEnumerator StartNewStage()
    {
        stageText.text = $"Stage {++stageNum}";
        DestroyCubes();
        cubePosList.Clear();

        GameManager.instance.plane.BasicSetting();
        GameManager.instance.plane.isLoading = true;
        //Debug.Log("CHILD:"+GameManager.instance.cube.transform.childCount);
        yield return new WaitForSeconds(0.1f);
        //Debug.Log("CHILDAFTER:" + GameManager.instance.cube.transform.childCount);
        GameManager.instance.plane.isLoading = false;

        cubes.transform.rotation = Quaternion.identity;

        for (int i = 0; i < cubeCnt; i++)
        {
            cubeList.Add(i);
        }
        //int cnt = Random.Range(1, cubeCnt);
        int cnt = SampleGaussian(1, cubeCnt);

        // 첫 큐브 생성
        Vector3 center = spawnPoints[Random.Range(0, cubeCnt - 1)];
        var tmp = Instantiate(cube, center, Quaternion.identity);
        tmp.transform.parent = cubes;

        // 이후 큐브 생성
        for (int i = 0; i < cnt - 1; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if ((center + directions[j]).x <= stageIdx - 1 && (center + directions[j]).x >= -stageIdx + 1 &&
                    (center + directions[j]).y <= stageIdx - 1 && (center + directions[j]).y >= -stageIdx + 1 &&
                    (center + directions[j]).z <= stageIdx - 1 && (center + directions[j]).z >= -stageIdx + 1)
                {
                    cubePosList.Add(center + directions[j]);
                }
            }

            Vector3 ranPos = cubePosList[Random.Range(0, cubePosList.Count)];
            var go = Instantiate(cube, ranPos, Quaternion.identity);
            go.transform.parent = cubes;

            center = ranPos;
            cubePosList.Remove(ranPos);
        }

        DeterminePlane();
        ConstructPlane();

        GameManager.instance.gameOverPanel.SetActive(false);
        GameManager.instance.gameOverPanel.transform.GetChild(1).gameObject.SetActive(false);
        GameManager.instance.gameOverPanel.transform.GetChild(2).gameObject.SetActive(false);
    }

    void DeterminePlane()
    {
        for (int i = 0; i < stageIdx * stageIdx; i++)
        {
            data[i / stageIdx, i % stageIdx] = false;
        }
        RaycastHit hit;
        int index = Random.Range(0, 6);
        //index = 0;
        bool isRay;
        for (int i = -stageIdx + 1; i <= stageIdx - 1; i+=2)
        {
            for (int j = -stageIdx + 1; j <= stageIdx - 1; j+=2)
            {
                Vector3 curPos = positions[index] + DetermineLoc(j, i, index);
                isRay = Physics.Raycast(curPos, directions[index], out hit, 8.0f);//, ~(1<<6));
                if (isRay)
                {
                    //Debug.Log(hit.distance + "\t" + hit.collider.transform.position);
                    data[(i+stageIdx-1)/2, (j+stageIdx-1)/2] = true;
                }
            }
        }
        //Debug.Log(index + "\t" + data[0, 0] + " " + data[0, 1] + " " + data[0, 2] + "\t" + data[1, 0] + " " + data[1, 1] + " " + data[1, 2] + "\t" + data[2, 0] + " " + data[2, 1] + " " + data[2, 2] + " ");
    }
    private Vector3 DetermineLoc(int i, int j, int index)
    {
        switch (index)
        {
            case 0:
                return new Vector3(i, - j, 0);
            case 1:
                return new Vector3(i, 0, - j);
            case 2:
                return new Vector3(- i, - j, 0);
            case 3:
                return new Vector3(- i, 0, - j);
            case 4:
                return new Vector3(0, - j, i);
            case 5:
                return new Vector3(0, - j, - i);
            default:
                Debug.Log("indexError");
                return new Vector3(-100, -100, -100);

        }
    }

    private void ConstructPlane()
    {
        int rot = Random.Range(0, 4);
        // rot = 0;
        GameManager.instance.plane.trigger.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90.0f * rot));
        //Debug.Log(rot);
        for (int i = 0; i < stageIdx * stageIdx; i++)
        {
            if (!GameManager.instance.stage.data[i / stageIdx, i % stageIdx])
            {
                GameObject go = Instantiate(GameManager.instance.plane.triggerPrefab);
                go.transform.parent = GameManager.instance.plane.trigger.transform;
                go.transform.position = new Vector3(-stageIdx + 1 + i / stageIdx * 2, -stageIdx + 1 + i % stageIdx * 2, 0);
                go.transform.localPosition = go.transform.localPosition - new Vector3(0, 0, go.transform.localPosition.z);
            }
        }

    }
    private void DestroyCubes()
    {
        for (int i = 0; i < GameManager.instance.cube.transform.childCount; i++)
        {
            Destroy(GameManager.instance.cube.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < GameManager.instance.plane.trigger.transform.childCount; i++)
        {
            Destroy(GameManager.instance.plane.trigger.transform.GetChild(i).gameObject);
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
