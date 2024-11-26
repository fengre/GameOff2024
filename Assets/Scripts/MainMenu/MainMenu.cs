using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : BasePanelManager
{
    
    public GameObject creditsPanel;
    

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
