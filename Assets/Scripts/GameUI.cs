using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameUI : MonoBehaviour
{
    private InputField inputField;
    private string playerName = "";
    public TextMeshProUGUI textLabel;
    public TextMeshProUGUI textHighscore;


    private void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();

        try 
        {
            playerName = BetweenScenes.Instance.playerName;
        }
        finally
        {
            inputField.text = playerName;
        }
        Highscore.Instance.LoadHighscore();
        textHighscore.text = Highscore.Instance.PresentHighscore();
    }

    public void resetHighscore()
    {
        Highscore.Instance.SaveHighscore(true);
        Highscore.Instance.LoadHighscore();
        textHighscore.text = Highscore.Instance.PresentHighscore();
    }


    public void startGame()
    {
        // at this point it only checks if the input field works
        playerName = inputField.text;
        if (playerName != "")
        {
            // save the inserted name into the between scene storage
            BetweenScenes.Instance.playerName = playerName;
            // start the game
            SceneManager.LoadScene(1);
        }
        else
        {
            textLabel.text = "Name needed!!!";

        }
    }

    public void endGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
