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
    public GameObject[] cubes = new GameObject[9];
    public GameObject collection;
    bool isCollision = false;
    bool isLack = false;
    bool accelerated = false;
    public bool isLoading = false;
    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (!GM.isFreeze)
        {
            if (!accelerated && Input.GetKeyDown(KeyCode.X))
            {
                speed *= 3;
                time /= 3;
                curTime /= 3;
                accelerated = true;
            }
            if (accelerated && Input.GetKeyUp(KeyCode.X))
            {
                speed /= 3;
                time *= 3;
                curTime *= 3;
                accelerated = false;
            }
            if (!isLoading)
            {
                if (isCollision)
                {
                    isLoading = true;
                    GameManager.instance.gameOverPanel.SetActive(true);
                    GameManager.instance.gameOverPanel.transform.GetChild(1).gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    isCollision = false;
                    // Debug.Log("GAME OVER! by Collision");
                }
                curTime += Time.deltaTime;
                if (curTime >= time)
                {
                    LackTest();
                    if (isLack)
                    {
                        GameManager.instance.gameOverPanel.SetActive(true);
                        GameManager.instance.gameOverPanel.transform.GetChild(2).gameObject.SetActive(true);
                        // Debug.Log("GAME OVER! by Lack");
                        Time.timeScale = 0f;
                        isLack = false;
                        isLoading = true;
                    }
                    else
                    {
                        if (accelerated)
                        {
                            accelerated = false;
                            speed /= 3;
                            time *= 3;
                        }
                        StartCoroutine(GameManager.instance.stage.StartNewStage());
                    }


                }
                else
                {
                    transform.position += (Camera.main.transform.position - transform.position).normalized * Time.deltaTime * speed;
                }
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        isCollision = true;
    }

    private void LackTest()
    {
        RaycastHit hit;
        float maxDist = 7.5f;

        bool isRay;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 curPos = new Vector3(0, 0, 4.5f) + new Vector3(1 - i, 1 - j, 0) * 2;
                isRay = Physics.Raycast(curPos, new Vector3(0, 0, -1), out hit, maxDist);
                if (!isRay)
                {
                    Debug.Log(i + "" + j);
                    isLack = true;
                    return;
                }
            }
        }
    }
    public void BasicSetting() // 나중에 인자 추가 필요
    {
        time = (firstDist + 2f) / speed;
        curTime = 0.0f;
        transform.position = GameManager.instance.cube.gameObject.transform.position + new Vector3(0, 0, firstDist);
    }
}

