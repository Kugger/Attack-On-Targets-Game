using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public float x = 0, y = 0, z = 0;

    public bool waving = false;

    void Update()
    {
        if (waving == true) 
        {
            transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);

            transform.position = transform.up + new Vector3(transform.position.x, Mathf.Sin(Time.time * 2f) * .5f, transform.position.z) ;
        } else
        {
            transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
        }
    }
}
