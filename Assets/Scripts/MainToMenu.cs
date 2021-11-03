using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToMenu : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
