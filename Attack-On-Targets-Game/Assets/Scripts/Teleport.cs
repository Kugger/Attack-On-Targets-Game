using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Scene");
        SceneManager.LoadScene("Tut2");
    }
}
