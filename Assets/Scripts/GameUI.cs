using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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


}
