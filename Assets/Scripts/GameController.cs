using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Self-Referenz

    public GameController Self;

    private string currentName;
    private string topscoreName;
    private int topscoreValue;


    void Awake()
    {
        if(Self==null)
        {
            Self = this;
            DontDestroyOnLoad(this);

        }
        else
        {
            Destroy(this);
        }


    }


    public void SetCurrentName(string name)
    {
        currentName = name;
    }

    public string GetCurrentName()
    {
        return currentName;
    }

    public void SetTopscoreName(string name)
    {
        topscoreName = name;
    }

    public string GetTopscoreName()
    {
        return topscoreName;
    }


    public void SetTopScore(int score)
    {
        if (score> topscoreValue)
        {
            topscoreName = currentName;
            topscoreValue = score;
        }        
    }

    public int GetTopscore()
    {
        return topscoreValue;
    }





    [System.Serializable]
    class SaveData_LastPlayer
    {
        public string LastPlayer;
    }

    public void SaveLastPlayer()
    {
        SaveData_LastPlayer data = new SaveData_LastPlayer();
        data.LastPlayer = currentName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile_lastplayer.json", json);
    }

    public void LoadLastPlayer()
    {
        string path = Application.persistentDataPath + "/savefile_lastplayer.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData_LastPlayer data = JsonUtility.FromJson<SaveData_LastPlayer>(json);

            currentName = data.LastPlayer;
        }
    }




    [System.Serializable]
    class SaveData_Topscore
    {
        public string TopScorePlayer;
        public int TopScoreValue;
    }

    public void SaveTopscore()
    {
        SaveData_Topscore data = new SaveData_Topscore();
        data.TopScorePlayer = topscoreName;
        data.TopScoreValue = topscoreValue;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile_topscore.json", json);
    }

    public void LoadTopscore()
    {
        string path = Application.persistentDataPath + "/savefile_topscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData_Topscore data = JsonUtility.FromJson<SaveData_Topscore>(json);

            topscoreName = data.TopScorePlayer;
            topscoreValue = data.TopScoreValue;
        }
    }


}
