using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class StoreName : MonoBehaviour
{
    public static StoreName Instance;


    public string playerName = "DefaultName";
    public int playerScore = 0;

    public HighScores data;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            Instance.data = new HighScores();
            LoadHighScore();
        }
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }

    [Serializable]
    public class HighScores
    {
        public string[] playerNames = new string[5];
        public int[] playerScores = new int[5];
    }

    public void AddHighScore(int score)
    {
        int position = -1;

        for (int i = 0; i < data.playerScores.Length; i++)
        {
            if (score > data.playerScores[i])
            {
                position = i;
                break;
            }
        }
        if (position == -1 && data.playerScores.Length > 5) return;
        if (data.playerScores.Length == 0) position = 0;
        if (position == -1) position = data.playerScores.Length;



        

        for (int i = 4; i > position; i--)
        {
            data.playerScores[i] = data.playerScores[i-1];
            data.playerNames[i] = data.playerNames[i - 1];
        }

        data.playerScores[position] = score;
        data.playerNames[position] = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<HighScores>(json);
        }
        else
        {
            data = new HighScores();
        }
    }


}
