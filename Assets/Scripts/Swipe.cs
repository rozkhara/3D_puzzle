using UnityEngine;

public class Swipe : MonoBehaviour
{
    //bool dragging = false;
    CubeController cubeController;
    Rigidbody rb;
    Vector2 prevLoc, CurLoc;

    [SerializeField]
    private float sensitivity;

    private bool determinedDir = false;
    private int rotDir = -1;
    private bool onTracking = false;
    private float cumulatedX=0f;
    private float cumulatedY=0f;
    // Start is called before the first frame update
    void Start()
    {
        sensitivity = 2f;

        rb = GetComponent<Rigidbody>();
        cubeController = GameManager.instance.cube;
        //screenMidPoint = GameObject.Find("Canvas").GetComponent<Canvas>().gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"ontracking:{onTracking}, determinedDir:{determinedDir}, rotDir{rotDir}");

        if (cubeController.rotationLock)
            return;
        if (onTracking)
        {
            prevLoc = CurLoc;
            CurLoc = Input.mousePosition;
            Vector2 movVec = CurLoc - prevLoc;
            //not determined whether rotate along x/y or cw yet
            if (!determinedDir)
            {
                cumulatedX += Vector2.Dot(Vector2.right, movVec);
                cumulatedY += Vector2.Dot(Vector2.up, movVec);
                //determineLoc when gap between magnitude of cumulate value exceeded specific value
                if (Mathf.Abs(Mathf.Abs(cumulatedX) - Mathf.Abs(cumulatedY)) > 100 - sensitivity*20)
                {
                    determinedDir = true;
                    if(Mathf.Abs(cumulatedX) > Mathf.Abs(cumulatedY))
                    {
                        rotDir = 0;
                    }
                    else
                    {
                        rotDir = 1;
                    }
                }
            }
            else
            {
                //rotation left and right
                if(rotDir == 0)
                {
                    GameManager.instance.stage.cubes.Rotate(Vector2.Dot(Vector2.right, movVec.normalized) * sensitivity * Vector2.down, Space.World);
                }
                else
                {
                    GameManager.instance.stage.cubes.Rotate(Vector2.Dot(Vector2.up, movVec.normalized) * sensitivity * Vector2.right, Space.World);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            CurLoc = Input.mousePosition;
            Debug.Log("initPos is " + CurLoc);
            onTracking = true;
        }
        if (Input.GetMouseButtonUp(0) && !(GameManager.instance.isFrozen) && !(GameManager.instance.isGameOver))
        {
            onTracking = false;
            //cw rotation
            if (!determinedDir && Mathf.Abs(cumulatedY)<= sensitivity/2000f && Mathf.Abs(cumulatedX)<= sensitivity/2000f)
            {
                cubeController.RotToTarget(Quaternion.Euler(Vector3.forward * -90)*GameManager.instance.stage.cubes.rotation);
                cumulatedX = 0f;
                cumulatedY = 0f;
                return;
            }
            cumulatedX = 0f;
            cumulatedY = 0f;
            determinedDir = false;
            Quaternion cubeRot = GameManager.instance.stage.cubes.transform.rotation;
            //Round Rotation
            Quaternion targetRot = Quaternion.Euler(new Vector3(((int)(cubeRot.eulerAngles.x / 90) + (int)((cubeRot.eulerAngles.x%90)/45)) *90, ((int)(cubeRot.eulerAngles.y / 90) + (int)((cubeRot.eulerAngles.y % 90) / 45)) * 90, ((int)(cubeRot.eulerAngles.z / 90) + (int)((cubeRot.eulerAngles.z % 90) / 45)) * 90));
            cubeController.RotToTarget(targetRot);
        }
    }
    private void PlayRandomSound()
    {
        if (Random.Range(0, 2) == 0)
        {
            SoundManager.Instance.PlaySFXSound("Click1", 0.65f);
        }
        else
        {
            SoundManager.Instance.PlaySFXSound("Click2", 0.65f);
        }
    }
}