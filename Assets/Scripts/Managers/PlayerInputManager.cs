using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    //public GameObject playerInputPanel;
    //public GameObject gamePanel;

    //Stores the name, hides input panel, triggers opening scene
    public void OnSubmitName()
    {
        PlayerData.playerName = nameInputField.text;
        //playerInputPanel.SetActive(false);

        if (SceneManagement.Instance != null)
        {
            SceneManagement.Instance.PlayGame();
        }
    }

    private void ShowOpeningScene()
    {
        //gamePanel.SetActive(true);
        //TBD
    }
}
