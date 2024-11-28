using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePanelManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider musicVolumeSlider;
    public Slider ambientVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        if (AudioManager.Instance != null)
        {
            //Initialize sliders with saved values
            if (musicVolumeSlider != null)
            {
                musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();
                musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
            }

            if (ambientVolumeSlider != null)
            {
                ambientVolumeSlider.value = AudioManager.Instance.GetAmbientVolume();
                ambientVolumeSlider.onValueChanged.AddListener(UpdateAmbientVolume);
            }

            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = AudioManager.Instance.GetSFXVolume();
                sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolume);
            }
        }
    }
    private void OnDestroy()
    {
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.RemoveListener(UpdateMusicVolume);
        }

        if (ambientVolumeSlider != null)
        {
            ambientVolumeSlider.onValueChanged.RemoveListener(UpdateAmbientVolume);
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.RemoveListener(UpdateSFXVolume);
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

    private void UpdateMusicVolume(float volume)
    {
        AudioManager.Instance?.SetMusicVolume(volume);
    }

    private void UpdateAmbientVolume(float volume)
    {
        AudioManager.Instance?.SetAmbientVolume(volume);
    }

    private void UpdateSFXVolume(float volume)
    {
        AudioManager.Instance?.SetSFXVolume(volume);
    }
}
