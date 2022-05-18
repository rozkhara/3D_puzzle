using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    public GameObject trigger;
    [SerializeField]
    private float speed;
    private float time;
    public float firstDist;
    private float curTime;
    [HideInInspector]
    public bool isCollision = false;
    bool isLack = false;
    bool accelerated = false;
    bool tripleAccelerated = false;
    public bool isLoading = false;
    //private float multiplier = 1f;
    public float Multiplier { get; set; }
    public GameObject triggerPrefab;
    private bool multiplyLock = false;
    GameManager GM;
    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Multiplier = 1 / Mathf.Pow(2, 0.01f);
        setSize();
    }
    private void FixedUpdate()
    {
    }

    void Update()
    {
        if (!tripleAccelerated && !accelerated && Input.GetKeyDown(KeyCode.X))
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
        if (!tripleAccelerated && !accelerated && Input.GetKeyDown(KeyCode.Z))
        {
            speed *= 9;
            time /= 9;
            curTime /= 9;
            tripleAccelerated = true;
        }
        if (tripleAccelerated && Input.GetKeyUp(KeyCode.Z))
        {
            speed /= 9;
            time *= 9;
            curTime *= 9;
            tripleAccelerated = false;
        }
        if (!isLoading)
        {
            if (isCollision)
            {
                isLoading = true;
                GameManager.instance.gameOverPanel.SetActive(true);
                GameManager.instance.gameOverPanel.transform.GetChild(1).gameObject.SetActive(true);
                GameManager.instance.isGameOver = true;
                Time.timeScale = 0f;
                if (SceneManager.GetActiveScene().name == "EasyScene")
                {
                    if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_easy)
                    {
                        GameManager.instance.highscore_easy = GameManager.instance.stage.stageNum;
                        PlayerPrefs.SetInt("highscoreeasy", GameManager.instance.highscore_easy);
                        PlayerPrefs.Save();
                    }

                }
                else if (SceneManager.GetActiveScene().name == "MediumScene")
                {
                    if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_medium)
                    {
                        GameManager.instance.highscore_medium = GameManager.instance.stage.stageNum;
                        PlayerPrefs.SetInt("highscoremedium", GameManager.instance.highscore_medium);
                        PlayerPrefs.Save();
                    }
                }
                else if (SceneManager.GetActiveScene().name == "HardScene")
                {
                    if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_hard)
                    {
                        GameManager.instance.highscore_hard = GameManager.instance.stage.stageNum;
                        PlayerPrefs.SetInt("highscorehard", GameManager.instance.highscore_hard);
                        PlayerPrefs.Save();
                    }
                }

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
                    GameManager.instance.isGameOver = true;
                    // Debug.Log("GAME OVER! by Lack");
                    Time.timeScale = 0f;
                    if (SceneManager.GetActiveScene().name == "EasyScene")
                    {
                        if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_easy)
                        {
                            GameManager.instance.highscore_easy = GameManager.instance.stage.stageNum;
                            PlayerPrefs.SetInt("highscoreeasy", GameManager.instance.highscore_easy);
                            PlayerPrefs.Save();
                        }

                    }
                    else if (SceneManager.GetActiveScene().name == "MediumScene")
                    {
                        if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_medium)
                        {
                            GameManager.instance.highscore_medium = GameManager.instance.stage.stageNum;
                            PlayerPrefs.SetInt("highscoremedium", GameManager.instance.highscore_medium);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (SceneManager.GetActiveScene().name == "HardScene")
                    {
                        if (GameManager.instance.stage.stageNum > GameManager.instance.highscore_hard)
                        {
                            GameManager.instance.highscore_hard = GameManager.instance.stage.stageNum;
                            PlayerPrefs.SetInt("highscorehard", GameManager.instance.highscore_hard);
                            PlayerPrefs.Save();
                        }
                    }
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
                    else if (tripleAccelerated)
                    {
                        tripleAccelerated = false;
                        speed /= 9;
                        time *= 9;
                    }
                    StartCoroutine(GameManager.instance.stage.StartNewStage());
                }
            }
            else
            {
                transform.position += new Vector3(0.0f, 0.0f, -1.0f) * Time.deltaTime * speed * Multiplier;
                trigger.transform.position += new Vector3(0.0f, 0.0f, -1.0f) * Time.deltaTime * speed * Multiplier;
            }
        }
    }

    private void LackTest()
    {
        RaycastHit hit;

        bool isRay;
        for (int i = 0; i < GM.stageIdx; i++)
        {
            for (int j = 0; j < GM.stageIdx; j++)
            {
                Vector3 curPos = new Vector3(0, 0, 1.5f * GM.stageIdx) + new Vector3(-GM.stageIdx + 1 + i * 2, -GM.stageIdx + 1 + j * 2, 0);
                isRay = Physics.Raycast(curPos, new Vector3(0, 0, -1), out hit, Mathf.Infinity);
                if (!isRay)
                {
                    Debug.Log($"{i},{j}");
                    isLack = true;
                    return;
                }
            }
        }
    }
    public void BasicSetting() // 나중에 인자 추가 필요
    {
        if (!multiplyLock)
        {
            Multiplier = Mathf.Min(Multiplier * Mathf.Pow(2, 0.01f), 2.0f);
            if (Multiplier == 2.0f)
            {
                multiplyLock = true;
            }
        }
        time = (firstDist + (GM.stageIdx - 1)) / speed / Multiplier;
        curTime = 0.0f;
        transform.position = GameManager.instance.cube.gameObject.transform.position + new Vector3(0, 0, firstDist);
        trigger.transform.position = GameManager.instance.cube.gameObject.transform.position + new Vector3(0, 0, firstDist);
    }
    private void setSize()
    {
        transform.localScale = new Vector3(transform.localScale.x * GM.stageIdx, transform.localScale.y * GM.stageIdx, transform.localScale.z);
    }
}

