using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySlot[] inventorySlots; // UI slots
    public GameObject inventoryUIPanel; // The UI panel to hold the inventory
    public DescriptionPanel descriptionPanel; // The UI panel to hold the inventory
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button viewButton;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        inventoryUIPanel.SetActive(false);
        viewButton.gameObject.SetActive(false);
        inventoryButton.onClick.AddListener(ShowPanel);
        closeButton.onClick.AddListener(HidePanel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HidePanel();
        }
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
                inventorySlots[i].onSlotClicked = null;
                inventorySlots[i].onSlotClicked += ShowDescriptionPanel;
                inventorySlots[i].onSlotClicked += AddOutline;
                inventorySlots[i].onSlotClicked += RemoveOutline;
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

    private void AddOutline(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].currentItem == item)
            {
                inventorySlots[i].AddOutline();
                return;
            }
        }
    }

    private void RemoveOutline(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].currentItem != item)
            {
                inventorySlots[i].RemoveOutline();
            }
        }
    }

    private void ShowPanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.backpackOpenSFX);
        inventoryUIPanel.SetActive(true);
        ResetPanel();
        UpdateInventoryUI();
    }

    private void ResetPanel()
    {
        // TODO: other sorts of resetting
        descriptionPanel.Hide();
    }

    private void HidePanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.backpackCloseSFX);
        inventoryUIPanel.SetActive(false);
    }
}
