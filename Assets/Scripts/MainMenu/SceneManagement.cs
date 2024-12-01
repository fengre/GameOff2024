using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Create a singleton instance
    public static SceneManagement Instance {get; private set;}
    public FadeManager fadeManager;

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

   

    public void StartGame()
    {
        StartCoroutine(TransitionToScene("StartScene"));
    }

    public void PlayGame()
    {
        StartCoroutine(TransitionToScene("VillageSquare"));
    }

    public void LoadSceneByName(string sceneName)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene cannot be found in the build settings.");
        }
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        //Fade out
        if (fadeManager != null)
        {
            yield return fadeManager.FadeOut();
        }

        //Load new scene
        SceneManager.LoadScene(sceneName);
    }
    
    //Reset PlayerData & return to MainMenu
    public void ResetGameState()
    {
        //Update more logic later
        PlayerData.playerName = "";
        PlayerData.CollectedItems.Clear();
        PlayerData.LensPosition = Vector3.zero;
        PlayerData.PlacedSecrets.Clear();

        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);
    }

}
