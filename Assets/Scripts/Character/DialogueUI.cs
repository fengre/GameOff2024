using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUIPanel;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private ItemPickupUI itemPickupUI;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
        SetButtons(true);
        Hide();
    }

    private void Hide()
    {
        dialogueUIPanel.SetActive(false);
    }

    public void ShowPanel(Character character, bool hasReceivedItem, bool firstShow)
    {
        characterNameText.text = character.characterName;
        dialogueText.text = character.GetDialogue(hasReceivedItem);
        if (hasReceivedItem && firstShow)
        {
            SetButtons(false);
            nextButton.onClick.AddListener(() => {
                Hide();
                itemPickupUI.ShowPanel(character.secret);
            });
        }
        else
        {
            SetButtons(true);
        }
        dialogueUIPanel.SetActive(true);
    }

    private void SetButtons(bool close)
    {
        closeButton.gameObject.SetActive(close);
        nextButton.gameObject.SetActive(!close);
    }
}
