using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : BasePanelManager
{
    public GameObject creditsPanel;

    public void OpenCredits()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        creditsPanel.SetActive(false);
    }

    public void OpenPortfolio(string url)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        Application.OpenURL(url);
    }
}
