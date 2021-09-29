using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string c_playerName = "";
    public string h_playerName = "";
    public int h_highScore = 0;

    [System.Serializable]
    public class PlayerHighScore
    {
        public string scoreName;
        public int score;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore(); // Watch out for the initialization order
    }
   
    // Called in unity at nameinputfield
    public void GetEnteredName()
    {
        c_playerName = MenuUI.UIInstance.GetEnteredName();
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerHighScore pastHighScore = JsonUtility.FromJson<PlayerHighScore>(json);
            h_playerName = pastHighScore.scoreName;
            h_highScore = pastHighScore.score;
            MenuUI.UIInstance.SetHighScore(h_playerName, h_highScore);
        }
    }
}
