using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Diagnostics;
//using System;

// to jest bardzo tez prosty skrypt
// do obslugi HUD informacji o
// ilosci strzal
//
// jednakze nie jest on idealny
// poniewaz nie bierzemy wartosci
// z Shoot tylko sami ja tutaj przypisujemy
// jest to takie szysbkie rozwiazanie
// moze kiedys to lepiej zrobie ~Kacper
//
// 17.05.2020
// kod poprawiony
// czyli nie trzeba tylu zmiennych
// wszystko jest w Shoot
//
// Script by Kacper

public class QuiverManager1 : MonoBehaviour
{
    [SerializeField]
    Text numberOfArrowsText; // tutaj bedziemy przypisywac nasz tekst

    int numberOfArrowsInt;
    int numberOfTargetsInt;

    void Update() // metoda ktora nasluchuje caly czas
    {
        GameObject ArrowSpawnPosition = GameObject.Find("ArrowSpawnPosition"); // znajduje obiekt ArrowSpawnPosition do ktorego przypisany jest skrypt Shoot
        Shoot shoot = ArrowSpawnPosition.GetComponent<Shoot>(); // zbiera komponenty (w tym wartosci) ze skryptu Shoot

        numberOfTargetsInt = GameObject.FindGameObjectsWithTag("Target").Length;
        numberOfArrowsInt = ArrowSpawnPosition.GetComponent<Shoot>().numberOfArrows;

        Debug.Log("arrows: " + numberOfArrowsInt);
        Debug.Log("tergets: " + numberOfTargetsInt);

        
        if (numberOfTargetsInt <= 0 || numberOfArrowsInt <= 0) //był zły znak i brak tagu na tarczach lepiej chyba or zamiast end /lykai debug
        {
            GameObject.Find("Timer").GetComponent<Timer>().TimeEnd(); // konczy czas timera /dopisal Lukayi 

            SceneManager.LoadScene("EndGame");
        }
        
        
        numberOfArrowsText.text = numberOfArrowsInt.ToString(); // wyswietlamy informacje
    }
}

