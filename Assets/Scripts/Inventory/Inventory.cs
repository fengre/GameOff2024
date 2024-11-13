using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; } // Singleton instance
    public List<Item> items = new List<Item>(); // List to store the inventory items
    public int maxInventorySize = 9; // Max number of items the inventory can hold

    private void Awake()
    {
        // Ensure only one instance of the Inventory exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy this duplicate instance if one already exists
        }
    }

    public void AddItem(Item item)
    {
        if (items.Count < maxInventorySize)
        {
            items.Add(item);
            Debug.Log(item.itemName + " has been added to the inventory.");
        }
        else
        {
            Debug.Log("Inventory is full.");
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " has been removed from the inventory.");
        }
    }

    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }
}
