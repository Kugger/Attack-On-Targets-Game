using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddArrowsPowerUp : MonoBehaviour
{
    [SerializeField]
    Text numberOfArrowsText; // tutaj bedziemy przypisywac nasz tekst

    public int numberOfArrowsInt;


    public void OnCollisionEnter(Collision collision)
    {
        GameObject ArrowSpawnPosition = GameObject.Find("ArrowSpawnPosition"); // znajduje obiekt ArrowSpawnPosition do ktorego przypisany jest skrypt Shoot
        Shoot shoot = ArrowSpawnPosition.GetComponent<Shoot>(); // zbiera komponenty (w tym wartosci) ze skryptu Shoot

        numberOfArrowsInt = ArrowSpawnPosition.GetComponent<Shoot>().numberOfArrows + 2;

        numberOfArrowsText.text = numberOfArrowsInt.ToString();

        Debug.Log("arrows: " + numberOfArrowsInt);

        /*
        GameObject SlowDownTimePU2 = GameObject.Find("SlowDownTimePU2");
        AddArrowsPowerUp numArrow = SlowDownTimePU2.GetComponent<AddArrowsPowerUp>();

        int iNumArrow = numArrow.numberOfArrowsInt;

        numberOfArrows = iNumArrow;
        */


        transform.parent.gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
    }
}
