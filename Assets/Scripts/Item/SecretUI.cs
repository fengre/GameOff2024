using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretUI : MonoBehaviour
{
    [SerializeField] private Image secretImage;
    [SerializeField] private GameObject secretUIPanel;
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private Character[] possibleSelfDialogues;
    [SerializeField] private float displayTime = 2f; // Time to display each image

    private void Awake()
    {
        ClosePanel();
    }

    public void ShowPanel(Sprite[] images)
    {
        secretUIPanel.SetActive(true);
        StartCoroutine(DisplayImages(images));
    }

    private IEnumerator DisplayImages(Sprite[] images)
    {
        foreach (Sprite image in images)
        {
            secretImage.sprite = image;
            // Wait for the specified time
            yield return new WaitForSeconds(displayTime);
        }

        ClosePanel();

        ShowSelfDialogue();
    }

    private void ShowSelfDialogue()
    {
        int randomNumber = Random.Range(0, possibleSelfDialogues.Length);
        Character selfDialogue = possibleSelfDialogues[randomNumber];

        dialogueUI.ShowPanel(selfDialogue, false, false);
    }

    private void ClosePanel()
    {
        secretUIPanel.SetActive(false);
    }
}
