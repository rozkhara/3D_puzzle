using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundCube : MonoBehaviour
{
    private Vector3 axis;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        axis = Random.onUnitSphere;
    }


    private void Update()
    {
        transform.Rotate(axis * 90 * Time.deltaTime, Space.World);

        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "SelectScene")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
