using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenes : MonoBehaviour
{
    public static BetweenScenes Instance;

    public string playerName;

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
}
