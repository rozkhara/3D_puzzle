using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // Start is called before the first frame update
    private float xVal;
    private float yVal; // ī�޶� ���� ����� 0,0���� �� �� ���� ���� ��ü�� ī�޶� �󿡼��� ��ǥ
                        // 0���� ���� �� (0,screen size) ������ ����ȭ�ȴ�.
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
        ratio = 1 / 3.0f; // ����, ���� �� ������ ���� 1/3�� �����ϵ��� ����
        width = Screen.width;
        height = Screen.height;
        Debug.Log($"{width}, {height}");
        if (height > width)
        {
            ratio = ratio / height * width;
        }
        cam = gameObject.GetComponent<Camera>();
        cam.orthographicSize = 6 / ratio; // 6( ť�� ������Ʈ�� ũ�� )�� ī�޶��� y�� ũ�⿡ ratio ��ŭ �����ϵ��� ���� 
        if (XMirror)
        {
            xVal = cam.orthographicSize / Screen.height * Screen.width * 2 - xVal;
        }
        if (xVal < 0) xVal += cam.orthographicSize / Screen.height * Screen.width * 2;
        if (yVal < 0) yVal += cam.orthographicSize * 2;
        cam.transform.position = new Vector3(-cam.orthographicSize /height * width + xVal ,-cam.orthographicSize+yVal,-10);
    }

}
