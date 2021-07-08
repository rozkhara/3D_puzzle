using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionDetection : MonoBehaviour
{
    private RaycastHit hit;
    private float maxDist = 15f;
    private bool[,] data = new bool[,] { { false, false, false }, { false, false, false }, { false, false, false } };
    private Vector3 curPos = new Vector3(0, 0, -5);

    // Update is called once per frame
    void Update()
    {
        bool isRay;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 curPos = new Vector3(i - 1, j - 1, -5);
                isRay = Physics.Raycast(curPos, new Vector3(0, 0, 1), out hit, maxDist, 1 << LayerMask.NameToLayer("Cube"));
                if (isRay)
                {
                    data[i, j] = true;
                }
                else
                {
                    data[i, j] = false;
                }
                
                Debug.DrawRay(curPos, new Vector3(0, 0, 15), Color.red);
            }
        }
        Debug.Log(data[0, 0] + " " + data[1, 0] + " " + data[2, 0] + "\t" + data[0, 1] + " " + data[1, 1] + " " + data[2, 1] + "\t" + data[0, 2] + " " + data[1, 2] + " " + data[2, 2] + " ");
    }
}
