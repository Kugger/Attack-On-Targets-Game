using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class TopTen : MonoBehaviour
{
    SaveScoreList save_list;
    Transform label;
    Transform SpeedLabel;

    void Awake()
    {
        label = transform.Find("ScoreText");
        label.gameObject.SetActive(false);


        string jsonString = File.ReadAllText(Application.dataPath + "/GameSaves/scores.json");
        if (String.IsNullOrEmpty(jsonString))
        {
            
        }
        else
        {
            save_list = JsonUtility.FromJson<SaveScoreList>(jsonString);
            save_list.scoreList = save_list.scoreList.OrderByDescending(x => x.score/(x.minutes*60+x.seconds)).ToList();//SORTOWANIE
            for (int i = 0; i < save_list.scoreList.Count && i < 5 ; i++)
            {

                Transform SpeedLabel = Instantiate(label, transform);
                SpeedLabel.position = new Vector3(250, 300 - (i * 70), 0);
                SpeedLabel.gameObject.SetActive(true);
                SpeedLabel.GetComponent<Text>().text = (i+1) + ". " + "Points: " + save_list.scoreList[i].score + ", time: "+ save_list.scoreList[i].minutes.ToString("00") + ":"+ save_list.scoreList[i].seconds.ToString("00");
            }
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
