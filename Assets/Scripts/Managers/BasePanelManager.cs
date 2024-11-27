using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePanelManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
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

    public void OpenSettings()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        settingsPanel.SetActive(false);
    }
}
