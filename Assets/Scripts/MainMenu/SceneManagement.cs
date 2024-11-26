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
        SceneManager.LoadScene("VillageSquare");
    }

    public void LoadSceneByName(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene cannot be found in the build settings.");
        }
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
