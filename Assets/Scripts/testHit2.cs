using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// testowanie skryptow do kolizji
// usunac gdy sie upewni ze niczym
// nie wadza i nie spowoduja bledow

public class testHit2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Traf2");
    }
}
