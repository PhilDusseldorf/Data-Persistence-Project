using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    private TMP_InputField inputField;
    private string playerName;

    public void Start()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        Debug.Log(inputField);
    }

    public void getPlayerName()
    {
        playerName = inputField.text;
    }

    public void startGame()
    {
        // at this point it only checks if the input field works
        Debug.Log("Player Name: " + playerName);
    }
}
