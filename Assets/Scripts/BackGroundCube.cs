using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCube : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 90 * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
