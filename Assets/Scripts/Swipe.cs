using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed = 100f;
    //bool dragging = false;
    CubeController cubeController;
    Rigidbody rb;
    float x, y;
    public bool rotationCheck, moveCheck;

    private bool isButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cubeController = GameManager.instance.cube;
    }

    //private void OnMouseDrag()
    //{
    //    dragging = true;
    //}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !(GameManager.instance.isFrozen) && !(GameManager.instance.isGameOver))
        {
            //dragging = false;
            if (Mathf.Abs(x) < 0.09f && Mathf.Abs(y) < 0.09f)
            {
                cubeController.CounterClock();
                PlayRandomSound();
            }
            else if (x != 0f || y != 0f)
            {
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x > 0)
                    {
                        cubeController.Right();
                        PlayRandomSound();
                    }
                    else
                    {
                        cubeController.Left();
                        PlayRandomSound();
                    }
                }
                else
                {
                    if (y > 0)
                    {
                        cubeController.Up();
                        PlayRandomSound();
                    }
                    else
                    {
                        cubeController.Down();
                        PlayRandomSound();
                    }
                }
            }
            x = 0f;
            y = 0f;
        }
        if (Input.GetMouseButtonUp(1) && !(GameManager.instance.isFrozen) && !(GameManager.instance.isGameOver))
        {
            cubeController.Clock();
            PlayRandomSound();
        }
    }

    private void FixedUpdate()
    {
        //if (dragging)
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            y += Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
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