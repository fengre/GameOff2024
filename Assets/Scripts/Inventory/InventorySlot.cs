using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon; // Image to show the item icon in the UI
    public Button slotButton; // Button that will be used to interact with the slot
    public System.Action<Item> onSlotClicked;
    public Outline outline;
    public Item currentItem; // The item assigned to this slot

    void Start()
    {
        slotButton.onClick.AddListener(OnSlotClick);
    }

    public void AssignItem(Item item)
    {
        currentItem = item;
        itemIcon.sprite = item.itemIcon; // Update the UI with the item icon
        itemIcon.enabled = true; // Make sure the icon is visible
        slotButton.interactable = true; // Enable interaction with the slot
        outline.enabled = false;
    }

    public void ClearSlot()
    {
        currentItem = null;
        itemIcon.sprite = null; // Clear the icon
        itemIcon.enabled = false; // Hide the icon
        slotButton.interactable = false; // Disable interaction with the slot
        outline.enabled = false;
    }

    private void OnSlotClick()
    {
        // If there's a listener for the event, invoke it
        if (onSlotClicked == null)
        {
            Debug.LogError("on slot clicked null");
        }
        onSlotClicked?.Invoke(currentItem);
    }

    public void AddOutline()
    {
        outline.enabled = true;
    }

    public void RemoveOutline()
    {
        outline.enabled = false;
    }
}
