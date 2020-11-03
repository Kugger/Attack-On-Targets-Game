using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Skrypt majacy za zadanie liczyc czas gry do mementu wystrzelania strzal
TimeEnd() musi zostac podpiete pod warunek konczacy gre

Lukasz
*/
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public Text timerText;
    private float timeStart;
    private float t;

    private bool end;

    public int minutes;//
    public int seconds;//

    void Start()
    {
        timeStart = Time.time;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
            return;

        t = Time.time - timeStart;

        minutes = ((int)t / 60);
        seconds = ((int)t % 60);//"f2" znaczy, ze bierze dwie liczby z floata
  

        timerText.text = "TIME: " + minutes.ToString("00") + ":" + seconds.ToString("00");//
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);//
    }

    public void TimeEnd()
    {
        end = true;
        timerText.color = Color.green;
    }
}
