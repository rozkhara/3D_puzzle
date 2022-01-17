using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float xVal;
    [SerializeField]
    private float yVal; // ī�޶� ���� ����� 0,0���� �� �� ���� ���� ��ü�� ī�޶� �󿡼��� ��ǥ
                        // 0���� ���� �� (0,screen size) ������ ����ȭ�ȴ�.
    private Camera cam;
    private float width;
    private float height;
    private float aspect;
    private float ratio;
    void Start()
    {
        ratio = 1 / 3.0f; // ����, ���� �� ������ ���� 1/3�� �����ϵ��� ����
        cam = gameObject.GetComponent<Camera>();
        width = Screen.width;
        height = Screen.height;
        if (height > width)
        {
            ratio = ratio / width * height;
        }
        cam.orthographicSize = 6/ratio; // 6( ť�� ������Ʈ�� ũ�� )�� ī�޶��� y�� ũ�⿡ ratio ��ŭ �����ϵ��� ���� 
        if (xVal < 0) xVal += cam.orthographicSize / Screen.height * Screen.width * 2;
        if (yVal < 0) yVal += cam.orthographicSize * 2;
        cam.transform.position = new Vector3(-cam.orthographicSize /height * width + xVal ,-cam.orthographicSize+yVal,-10);
    }

}
