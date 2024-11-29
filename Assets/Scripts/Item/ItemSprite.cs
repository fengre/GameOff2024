using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemSprite : MonoBehaviour, IClickable
{
    [SerializeField] private Item item; // Reference to the item that this object represents
    [SerializeField] private ItemPickupUI itemPickupUI;

    private void Start()
    {
        if (PlayerData.CollectedItems.Contains(item.itemName))
        {
            gameObject.SetActive(false); // Hide the item
        }
    }

    public void OnClick()
    {
        if (!PlayerData.CollectedItems.Contains(item.itemName))
        {
            PlayerData.CollectedItems.Add(item.itemName);
            CollectItem();
            gameObject.SetActive(false); // Hide or disable the item
        }
    }

    private void CollectItem()
    {
        Inventory.Instance.AddItem(item);
        itemPickupUI.ShowPanel(item);
        Debug.Log($"Collected item: {item.itemName}");
    }
}
