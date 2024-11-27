using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueUI : MonoBehaviour
{
    public event EventHandler EndDialogueEvent;

    [SerializeField] private GameObject dialogueUIPanel;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private ItemPickupUI itemPickupUI;

    private Character currCharacter;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => {
            NextDialogue(false);
        });
        SetButtons(true);
        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (closeButton.gameObject.activeSelf)
            {
                NextDialogue(false);
            }
            else if (nextButton.gameObject.activeSelf)
            {
                NextDialogue(true);
            }
        }
    }

    private void Hide()
    {
        dialogueUIPanel.SetActive(false);
    }

    public void ShowPanel(Character character, bool hasReceivedItem, bool firstShow)
    {
        currCharacter = character;
        characterNameText.text = character.characterName;
        dialogueManager.StartDialogue(character.GetDialogue(hasReceivedItem));
        if (hasReceivedItem && firstShow)
        {
            SetButtons(false);
            nextButton.onClick.AddListener(() => {
                NextDialogue(true);
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

    private void NextDialogue(bool showItemPickup)
    {
        bool displayLine = dialogueManager.DisplayNextLine();
        if (!displayLine)
        {
            Hide();
            if (showItemPickup)
            {
                itemPickupUI.ShowPanel(currCharacter.secret);
            }
            EndDialogueEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}