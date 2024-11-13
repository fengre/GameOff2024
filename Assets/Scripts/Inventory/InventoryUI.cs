using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySlot[] inventorySlots; // UI slots
    public GameObject inventoryPanel; // The UI panel to hold the inventory
    public DescriptionPanel descriptionPanel; // The UI panel to hold the inventory

    void Awake()
    {
        inventoryPanel.SetActive(false);
    }

    private void Start()
    {
        // Initialize the slots in the UI
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        // Loop through each slot in the inventory UI
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < Inventory.Instance.items.Count)
            {
                // Assign item to slot
                Item currItem = Inventory.Instance.items[i];
                inventorySlots[i].AssignItem(currItem);
                Debug.Log(i + " assign item " + currItem.itemName);
                inventorySlots[i].onSlotClicked += ShowDescriptionPanel;
            }
            else
            {
                // Clear the slot if there's no item
                inventorySlots[i].ClearSlot();
            }
        }
    }

    public void ShowDescriptionPanel(Item item)
    {
        // Show the description panel and update its contents
        descriptionPanel.ShowPanel(item);
    }

    public void ToggleInventory()
    {
        // Toggle inventory UI visibility
        if (inventoryPanel.activeSelf) {
            descriptionPanel.Hide();
        }
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        UpdateInventoryUI();
        
    }
}
