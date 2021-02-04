using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DubbCube : MonoBehaviour
{
    [SerializeField]
    AudioSource dubbSource;

    public GameObject scriptPanel;

    public void OnTriggerEnter(Collider other)
    {
        dubbSource.Play();

        scriptPanel.SetActive(true);
    }
}
