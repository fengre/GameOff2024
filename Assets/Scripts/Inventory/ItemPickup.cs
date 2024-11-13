using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item; // Reference to the item that this object represents
    [SerializeField] private ItemPickupUIPanel itemPickupUIPanel;

    private void OnMouseDown()
    {
        Inventory.Instance.AddItem(item);
        ShowPanel();
        Destroy(gameObject);
    }

    private void ShowPanel()
    {
        itemPickupUIPanel.ShowPanel(item);
    }
}
