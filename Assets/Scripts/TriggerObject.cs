using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.plane.isCollision = true;
    }
}
