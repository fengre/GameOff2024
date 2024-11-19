using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject creditsPanel;
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

    public void UpdateVolume(float volume)
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(volume);
        }
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void OpenPortfolio(string url)
    {
        Application.OpenURL(url);
    }
}
