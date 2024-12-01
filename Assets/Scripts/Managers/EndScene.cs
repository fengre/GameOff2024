using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public GameObject replayButton;

    [Header("Image and dialogue info")]
    public Image secretImage;
    public Image treeImage;
    public Image motherSisterImage;
    public Character[] characters;

    private int index = 0;
    private int secretIndex = 0;

    private void Start()
    {
        treeImage.gameObject.SetActive(false);
        motherSisterImage.gameObject.SetActive(false);
        secretImage.gameObject.SetActive(true);
        replayButton.SetActive(false);

        Character c = characters[index];
        secretImage.sprite = c.secret.secretImages[secretIndex];
        dialogueUI.ShowPanel(c, false, false);

        dialogueUI.NextDialogueEvent += DialogueUI_NextDialogueEvent;
        dialogueUI.EndDialogueEvent += DialogueUI_EndDialogueEvent;
    }

    private void DialogueUI_NextDialogueEvent(object sender, System.EventArgs e)
    {
        if (index < 5)
        {
            Character c = characters[index];
            secretIndex = Mathf.Min(secretIndex + 1, c.secret.secretImages.Length - 1);
            secretImage.sprite = c.secret.secretImages[secretIndex];
        }
    }

    private void DialogueUI_EndDialogueEvent(object sender, System.EventArgs e)
    {
         if (index + 1 < characters.Length)
        {
            index++;

            if (index < 5)
            {
                Character c = characters[index];
                secretIndex = 0;
                secretImage.sprite = c.secret.secretImages[secretIndex];
                dialogueUI.ShowPanel(c, false, false);
            }
            else
            {
                secretImage.gameObject.SetActive(false);
                treeImage.gameObject.SetActive(true);
                motherSisterImage.gameObject.SetActive(true);

                Character c = characters[index];
                dialogueUI.ShowPanel(c, false, false);
            }
        }
        else
        {
            StartCoroutine(FadeOutImage());
        }
    }

    private IEnumerator FadeOutImage()
    {
        float duration = 2f;
        float elapsedTime = 0f;

        Color startColor = motherSisterImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            motherSisterImage.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            yield return null;
        }

        motherSisterImage.color = targetColor;
        motherSisterImage.gameObject.SetActive(false);

        replayButton.SetActive(true);
    }

    public void ReplayPressed()
    {
        if (SceneManagement.Instance != null)
        {
            SceneManagement.Instance.ResetGameState();
        }
    }
}
