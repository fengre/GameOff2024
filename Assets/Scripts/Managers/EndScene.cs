using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public DialogueUI dialogueUI;

    [Header("Image and dialogue info")]
    public Image secretImage;
    public Character[] characters;
    public TextMeshProUGUI endingText;
    public GameObject blackPanel;

    private int index = 0;
    private int secretIndex = 0;

    private void Start()
    {
        endingText.text = "My sweet " + PlayerData.playerName + ", I should have known it was you all along. Thank you for uncovering our town's secret.";

        blackPanel.SetActive(false);

        Character c = characters[index];
        secretImage.sprite = c.secret.secretImages[secretIndex];
        dialogueUI.ShowPanel(c, false, false);

        dialogueUI.NextDialogueEvent += DialogueUI_NextDialogueEvent;
        dialogueUI.EndDialogueEvent += DialogueUI_EndDialogueEvent;
    }

    private void DialogueUI_NextDialogueEvent(object sender, System.EventArgs e)
    {
        Character c = characters[index];
        secretIndex = Mathf.Min(secretIndex + 1, c.secret.secretImages.Length - 1);
        secretImage.sprite = c.secret.secretImages[secretIndex];
    }

    private void DialogueUI_EndDialogueEvent(object sender, System.EventArgs e)
    {
        if (index + 1 < characters.Length)
        {
            index++;
            Character c = characters[index];
            secretIndex = 0;
            secretImage.sprite = c.secret.secretImages[secretIndex];
            dialogueUI.ShowPanel(c, false, false);
        }
        else
        {
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
