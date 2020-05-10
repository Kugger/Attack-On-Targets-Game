using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jest to skrypt do zazadzania uzyskanymi
// punktami jak mozna zauwazyc korzysta z 
// UI co za tym idzie rowniez wyswietlanie
// na ekranie
//
// ten skrypt bedzie istoty w zwiazku z
// zapisywaniem wynikow poniewaz jakims
// sposobem trzeba bedzie zliczac najlepsza
// wartosc zajmuje sie tym Julia
// pozyteczne rzeczy na yt po frazie
// unity score table

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // int do zliczania punktow

    public static ScoreManager instance; // instancja dostepu do ScoreManager

    [SerializeField]
    Text scoreText; // przypisanie obiektu TEXT z UI do wyswietlania

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString(); // wypisywanie calkowitego wyniku na ekran
    }
}
