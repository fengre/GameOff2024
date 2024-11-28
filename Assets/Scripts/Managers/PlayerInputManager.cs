using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject startButton;

    private void Start()
    {
        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        if (nameInputField != null)
        {
            nameInputField.onValueChanged.AddListener(OnNameInputChanged);
        }
    }

    private void OnDestroy()
    {
        if (nameInputField != null)
        {
            nameInputField.onValueChanged.RemoveListener(OnNameInputChanged);
        }
    }

    private void OnNameInputChanged(string input)
    {
        if (startButton != null)
        {
            startButton.SetActive(!string.IsNullOrWhiteSpace(input));
        }
    }

    //Stores the name, hides input panel, triggers opening scene
    public void OnSubmitName()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.startButtonSFX);
        PlayerData.playerName = nameInputField.text;
        if(SceneManagement.Instance != null)
        {
            SceneManagement.Instance.StartGame();
        }

    }
}
