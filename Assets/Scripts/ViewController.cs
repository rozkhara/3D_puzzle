using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera camera;
    private float width;
    private float height;
    private float aspect;
    private float ratio;
    void Start()
    {
        ratio = 1 / 3.0f;
        camera = gameObject.GetComponent<Camera>();
        width = Screen.width;
        height = Screen.height;
        if (height > width)
        {
            ratio = ratio / width * height;
        }
        camera.orthographicSize = 6/ratio;
        Debug.Log(6 / ratio);
        camera.transform.position = new Vector3(-camera.orthographicSize /height * width + 4 ,-camera.orthographicSize+4,-10);
    }

}
