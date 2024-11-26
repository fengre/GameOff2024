using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;


    //Stores the name, hides input panel, triggers opening scene
    public void OnSubmitName()
    {
        PlayerData.playerName = nameInputField.text;
        if(SceneManagement.Instance != null)
        {
            SceneManagement.Instance.PlayGame();
        }

    }
}
