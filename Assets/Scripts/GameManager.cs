using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string highScorePlayerName;
    public int highScore;
    public string currPlayerName;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScoreData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class ScoreData
    {
        public string playerName;
        public int highScore;
    }

    public void UpdateHighScore(int newHighScore, string newName)
    {
        if (newHighScore > highScore)
        {
            highScore = newHighScore;
            highScorePlayerName = newName;
        }
    }

    public void SaveScoreData()
    {
        ScoreData scoreData = new ScoreData();
        scoreData.playerName = highScorePlayerName;
        scoreData.highScore = highScore;

        string json = JsonUtility.ToJson(scoreData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);

            highScorePlayerName = scoreData.playerName;
            highScore = scoreData.highScore;
        }
    }
}
