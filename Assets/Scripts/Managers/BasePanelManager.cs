using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePanelManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;

    private void Start()
    {
        //Ensures slider matches current volume
        if(volumeSlider != null && AudioManager.Instance != null)
        {
            volumeSlider.value = AudioManager.Instance.GetVolume();
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }
    }
    private void OnDestroy()
    {
        if(volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(UpdateVolume);
        }
    }
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

    public void UpdateVolume(float volume)
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(volume);
        }
    }
}
