using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// kolejny prosty kod do obslugi
// HUDa a konkretnie pokazuje 
// wartosc naciagu
//
// troche po lebkach zrobione
// ale dziala
//
// 17.05.2020
// poprawilem kod ze teraz jest zalezny od
// skryptu Shoot wiec nie trzeba wszedzie
// zmieniac wystarczy tylko w Shoot albo
// przypisanym prefabie
//
// Script by Kacper

public class DrawManager : MonoBehaviour
{ 
    public Slider slider; // tutaj bedziemy przypisywac nasz slider

    void Update() 
    {
        GameObject ArrowSpawnPosition = GameObject.Find("ArrowSpawnPosition"); // znajduje obiekt ArrowSpawnPosition do ktorego przypisany jest skrypt Shoot
        Shoot shoot = ArrowSpawnPosition.GetComponent<Shoot>(); // zbiera komponenty (w tym wartosci) ze skryptu Shoot

        if (shoot.numberOfArrows > 0) // jesli strzal jest wiecej niz 0
        {
            if (shoot.pullAmount > 100) // jesli pullAmount powyzej 100
                shoot.pullAmount = 100; // to pullAmount rowna sie 100, musialem to pisac? xD

            if (Input.GetMouseButton(0)) // nacisniecie lewego klawisza myszy
            {
                shoot.pullAmount += shoot.pullSpeed * Time.deltaTime; // zwiekszamy naciag (pullAmount), dzieki deltaTime dziala to niezaleznie od klatkazu

                slider.value = shoot.pullAmount; // ustawiamy wartosc slidera taka jak pullAmount
            }

            if (Input.GetMouseButtonUp(0)) // puszczenie lewego klawisza myszy
            {
                shoot.pullAmount = 0; // zerujemy naciag

                slider.value = 0; // zerujemy slider, obecnie raczej bezuzyteczne
            }
        }
    }

    private void LateUpdate() // metoda potrzeba bo w Update slider sie nie zerowal i caly czas byl napiety
    {
        GameObject ArrowSpawnPosition = GameObject.Find("ArrowSpawnPosition"); // znajduje obiekt ArrowSpawnPosition do ktorego przypisany jest skrypt Shoot
        Shoot shoot = ArrowSpawnPosition.GetComponent<Shoot>(); // zbiera komponenty (w tym wartosci) ze skryptu Shoot

        if (shoot.numberOfArrows == 0)
        {
            slider.value = 0; // zerujemy slider
        }
    }
}
