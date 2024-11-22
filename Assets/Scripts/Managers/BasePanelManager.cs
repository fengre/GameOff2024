using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanelManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (SceneManagement.Instance != null)
        {
            SceneManagement.Instance.LoadSceneByName(sceneName);
        }
        else
        {
            Debug.LogError("SceneManagement instance is not available.");
        }
    }
}
