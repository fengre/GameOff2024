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
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ItemPickupUI itemPickupUI;
    [SerializeField] private BasicTogglerButton basicTogglerButton;
    [SerializeField] private float displayTime = 2f; // Time to display each image

    private bool inventoryUIOn = false;
    private bool itemPickupUIOn = false;
    private bool lensOn = false;

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
        TurnUIOff();

        foreach (Sprite image in images)
        {
            secretImage.sprite = image;
            // Wait for the specified time
            yield return new WaitForSeconds(displayTime);
        }

        ClosePanel();

        TurnUIOn();
        
        ShowSelfDialogue();
        
    }

    private void TurnUIOff()
    {
        if (inventoryUI.gameObject.activeSelf)
        {
            inventoryUIOn = true;
            inventoryUI.gameObject.SetActive(false);
        }

        if (itemPickupUI.gameObject.activeSelf)
        {
            itemPickupUIOn = true;
            itemPickupUI.gameObject.SetActive(false);
        }

        if (PlayerData.IsLensToggled)
        {
            lensOn = true;
            basicTogglerButton.toggledGO.SetActive(false);
        }
    }

    private void TurnUIOn()
    {
        if (inventoryUIOn)
        {
            inventoryUIOn = false;
            inventoryUI.gameObject.SetActive(true);
        }

        if (itemPickupUIOn)
        {
            itemPickupUIOn = false;
            itemPickupUI.gameObject.SetActive(true);
        }

        if (lensOn)
        {
            lensOn = false;
            basicTogglerButton.toggledGO.SetActive(true);
        }
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
