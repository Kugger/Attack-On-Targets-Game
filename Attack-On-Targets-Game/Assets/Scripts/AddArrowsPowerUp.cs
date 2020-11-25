using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddArrowsPowerUp : MonoBehaviour
{
    [SerializeField]
    Text numberOfArrowsText; // tutaj bedziemy przypisywac nasz tekst

    int numberOfArrowsInt;


    // Update is called once per frame
    void Update()
    {
        GameObject ArrowSpawnPosition = GameObject.Find("ArrowSpawnPosition"); // znajduje obiekt ArrowSpawnPosition do ktorego przypisany jest skrypt Shoot
        Shoot shoot = ArrowSpawnPosition.GetComponent<Shoot>(); // zbiera komponenty (w tym wartosci) ze skryptu Shoot

        numberOfArrowsInt = ArrowSpawnPosition.GetComponent<Shoot>().numberOfArrows;

        numberOfArrowsText.text = numberOfArrowsInt.ToString(); // wyswietlamy informacje
    }

    public void OnCollisionEnter(Collision collision)
    {
        numberOfArrowsInt += 2;

        numberOfArrowsText.text = numberOfArrowsInt.ToString();

        transform.parent.gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
    }
}
