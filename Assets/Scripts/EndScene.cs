using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    public TMP_Text playerNameText;

    private void Start()
    {
        playerNameText.text = "Player name: " + PlayerData.playerName;
    }

    public void ReplayPressed()
    {
        if (SceneManagement.Instance != null)
        {
            SceneManagement.Instance.ResetGameState();
        }
    }
}
