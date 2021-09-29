using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_InputField nameInputField;
    public static MenuUI UIInstance;

    private void Awake()
    {
        bestScoreText.text = "Best Score: ";
        UIInstance = this;
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public string GetEnteredName()
    {        
        string playerName = nameInputField.text;
        return playerName;
    }

    public void SetHighScore(string h_name, int h_score)
    {
        bestScoreText.text += $"{h_name}: {h_score}";
    }
}
