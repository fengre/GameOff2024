using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemSprite : MonoBehaviour, IClickable
{
    [SerializeField] private Item item; // Reference to the item that this object represents
    [SerializeField] private ItemPickupUI itemPickupUI;

    public void OnClick()
    {
        Inventory.Instance.AddItem(item);
        ShowPanel();
        Destroy(gameObject);
    }

    private void ShowPanel()
    {
        itemPickupUI.ShowPanel(item);
    }
}
