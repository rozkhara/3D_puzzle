using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    private float width;
    private float height;
    private float aspect;
    private float ratio;
    void Start()
    {
        ratio = 1 / 3.0f;
        cam = gameObject.GetComponent<Camera>();
        width = Screen.width;
        height = Screen.height;
        if (height > width)
        {
            ratio = ratio / width * height;
        }
        cam.orthographicSize = 6/ratio;
        cam.transform.position = new Vector3(-cam.orthographicSize /height * width + 4 ,-cam.orthographicSize+4,-10);
    }

}
