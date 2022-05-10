using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // Start is called before the first frame update
    private float xVal;
    private float yVal; // 카메라 우측 상단을 0,0으로 할 때 띄우고 싶은 물체의 카메라 상에서의 좌표
                        // 0보다 작을 시 (0,screen size) 범위로 정규화된다.
    [SerializeField]
    private bool XMirror;
    private Camera cam;
    private float width;
    private float height;
    private float aspect;
    private float ratio;
    void Start()
    {
        xVal = 4 + 2 * (GameManager.instance.stageIdx - 3);
        yVal = 4 + 2 * (GameManager.instance.stageIdx - 3);
        ratio = 1 / 3.0f; // 가로, 세로 중 작은것 기준 1/3을 차지하도록 설정
        width = Screen.width;
        height = Screen.height;
        Debug.Log($"{width}, {height}");
        if (height > width)
        {
            ratio = ratio / height * width;
        }
        cam = gameObject.GetComponent<Camera>();
        cam.orthographicSize = 6 / ratio; // 6( 큐브 오브젝트의 크기 )이 카메라의 y축 크기에 ratio 만큼 차지하도록 설정 
        if (XMirror)
        {
            xVal = cam.orthographicSize / Screen.height * Screen.width * 2 - xVal;
        }
        if (xVal < 0) xVal += cam.orthographicSize / Screen.height * Screen.width * 2;
        if (yVal < 0) yVal += cam.orthographicSize * 2;
        cam.transform.position = new Vector3(-cam.orthographicSize /height * width + xVal ,-cam.orthographicSize+yVal,-10);
    }

}
