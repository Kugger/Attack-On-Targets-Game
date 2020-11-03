using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


// taka wstepna wersja zapisujaca wyniki do tabeli wynikow
// nasptepnie powinna byc tak zrobiona by przechwytywac wynik z gry
// teraz w ramach testow sa po prostu dwa pola 

public class EndGameMenu : MonoBehaviour
{
    public int score;
    Text scr;
    int sec;
    int min;
    SaveScoreList save_list;


    public void LoadSampleScene()
    {
        Destroy(GameObject.Find("Canvas"));
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMainMenu()
    {
        Destroy(GameObject.Find("Canvas"));
        SceneManager.LoadScene("MainMenu");
    }
   
    void Start()
    {
        Cursor.visible = true; // wlaczenie kursora po grze poniewaz nie mozna klikac xD -- dop Lukai
        Cursor.lockState = CursorLockMode.None; // cofniecie zablokowania myszki

        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score;//wyciagamy score z objektu SM
        sec = GameObject.Find("Timer").GetComponent<Timer>().seconds;
        min = GameObject.Find("Timer").GetComponent<Timer>().minutes;

        CreateFile();

        SaveRes(score, min, sec);

        Destroy(GameObject.Find("ScoreManager")); // usuwamy obj ScoreManage pobierany z sceny SampleScene

    }

    void CreateFile()// tworzy file scores, jeżeli on nie istnieje
    {
        StreamWriter w = File.AppendText(Application.dataPath + "/GameSaves/scores.json");
        w.Close();
    }


    void SaveRes(int score, int minutes, int seconds)//odczytujemy poprzednie wyniki, czas(jezeli istnieja) i dopisujemy nowe
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/GameSaves/scores.json");
        if (String.IsNullOrEmpty(jsonString))
        {
            //wywoluje sie jezeli text odczytywany z pliku jest pusty
            //kiedy tworzymy plik po raz pierwszy 
            //tworzymy liste ktora zawiera objekty klasy SaveScore
            //klasy znajduja sie w pliku SaveScores.cs
            save_list = new SaveScoreList();
        }
        else
        {
            //jezeli text nie jest pusty to odczytujemy objekty typu SaveScoreList z pliku
            save_list = JsonUtility.FromJson<SaveScoreList>(jsonString);
        }

        SaveScore save = new SaveScore(); // tworzymy obj Save do ktorego zapisujemy scores, time
        save.score = score;
        save.minutes = minutes;
        save.seconds = seconds;

        save_list.scoreList.Add(save); // dodajemy ostatni wynik do odczytywanej listy

        string json = JsonUtility.ToJson(save_list, true); //konwertujemy obj typu SaveScoreList do json 
        File.WriteAllText(Application.dataPath + "/GameSaves/scores.json", json); // zapisujemy obj string json do pliku

    }

    
    


}
