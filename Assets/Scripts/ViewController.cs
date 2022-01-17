using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float xVal;
    [SerializeField]
    private float yVal; // 카메라 우측 상단을 0,0으로 할 때 띄우고 싶은 물체의 카메라 상에서의 좌표
                        // 0보다 작을 시 (0,screen size) 범위로 정규화된다.
    private Camera cam;
    private float width;
    private float height;
    private float aspect;
    private float ratio;
    void Start()
    {
        ratio = 1 / 3.0f; // 가로, 세로 중 작은것 기준 1/3을 차지하도록 설정
        cam = gameObject.GetComponent<Camera>();
        width = Screen.width;
        height = Screen.height;
        if (height > width)
        {
            ratio = ratio / width * height;
        }
        cam.orthographicSize = 6/ratio; // 6( 큐브 오브젝트의 크기 )이 카메라의 y축 크기에 ratio 만큼 차지하도록 설정 
        if (xVal < 0) xVal += cam.orthographicSize / Screen.height * Screen.width * 2;
        if (yVal < 0) yVal += cam.orthographicSize * 2;
        cam.transform.position = new Vector3(-cam.orthographicSize /height * width + xVal ,-cam.orthographicSize+yVal,-10);
    }

}
