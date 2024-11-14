using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [Header("Player Info")]
    public TMP_Text playerNameText;

    [Header("Image and dialogue info")]
    public Image[] images;
    public string[] dialogue;
    public TMP_Text dialogueText;
    public GameObject nextButton;
    public GameObject blackPanel;
    public GameObject endPanel;

    private int currentImageIndex = 0;

    private void Start()
    {
        playerNameText.text = "My sweet " + PlayerData.playerName + " , I should have known it was you all along. Thank you for uncovering our towns secret.";

        for(int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == 0);
        }

        if(dialogue.Length > 0)
        {
            dialogueText.text = dialogue[0];
        }

        blackPanel.SetActive(false);
    }

    public void NextButtonPressed()
    {
        images[currentImageIndex].gameObject.SetActive(false);

        currentImageIndex++;

        if(currentImageIndex < images.Length)
        {
            images[currentImageIndex].gameObject.SetActive(true);

            if(currentImageIndex < dialogue.Length)
            {
                dialogueText.text = dialogue[currentImageIndex];
            }
        }
        else
        {
            endPanel.SetActive(false);
            blackPanel.SetActive(true);
        }
    }

    public void ReplayPressed()
    {
        if (SceneManagement.Instance != null)
        {
            SceneManagement.Instance.ResetGameState();
        }
    }
}
