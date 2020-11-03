using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTargetsManager : MonoBehaviour
{
    GameObject[] children;

    [SerializeField]
    Text numberOfTargets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        children = GameObject.FindGameObjectsWithTag("Target");

        numberOfTargets.text = children.Length.ToString();
    }
}
