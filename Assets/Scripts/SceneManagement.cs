using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Create a singleton instance
    public static SceneManagement Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGame()
    {
        ResetGameState();
        SceneManager.LoadScene("OpeningScene");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }

    //Reset PlayerData & return to MainMenu
    public void ResetGameState()
    {
        //Update more logic later
        PlayerData.playerName = "";
        SceneManager.LoadScene("MainMenu");

        Destroy(gameObject);
    }
}
