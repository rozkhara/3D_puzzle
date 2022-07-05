using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
