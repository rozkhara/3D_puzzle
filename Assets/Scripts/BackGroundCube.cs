using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundCube : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 90 * Time.deltaTime, Space.World);

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
