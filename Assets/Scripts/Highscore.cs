using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Highscore : MonoBehaviour
{
    public static Highscore Instance;
    public string bestPlayer;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NewHighscore(string player, int newHighscore)
    {
        highScore = newHighscore;
        bestPlayer = player;
        Debug.Log("Highscore: " + highScore + " from " + bestPlayer);
    }

    public string PresentHighscore()
    {
        string scoreText;
        if (bestPlayer != "")
        {
            scoreText = $"Best Score: {bestPlayer} with {highScore} points";
        } else {
            scoreText = "Best Score: Not yet available";
        }
        return scoreText;
    }

    [System.Serializable]
    class SaveData
    {
        public string savedPlayer;
        public int savedScore;

    }

    public void SaveHighscore()
    {
        // create a new save object
        SaveData data = new SaveData();
        // store data in object
        data.savedPlayer = bestPlayer;
        data.savedScore = highScore;
        // create json string element
        string json = JsonUtility.ToJson(data);
        // write the string element into highscore.json
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighscore()
    {
        // define path to .json file
        string path = Application.persistentDataPath + "/highscore.json";
        // check if file exists
        if (File.Exists(path))
        {
            // read text from file into a string
            string json = File.ReadAllText(path);
            // create a SavaData object with string data
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            // store the SavaData object's elements into variables
            bestPlayer = data.savedPlayer;
            highScore = data.savedScore;
        }
    }
}
