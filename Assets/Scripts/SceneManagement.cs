using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private void Awake()
    {
        //Keep object across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame()
    {
        ResetGameState();
        SceneManager.LoadScene("OpeningScene");
    }

    private void ResetGameState()
    {
        //Update logic later
    }
}
