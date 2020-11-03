using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveScore
{
    public int score = 0;
    public int minutes = 0;
    public int seconds = 0;
}

[System.Serializable]
public class SaveScoreList
{
    public List<SaveScore> scoreList = new List<SaveScore>();
}