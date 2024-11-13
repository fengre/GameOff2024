using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public string itemName; // Name of the item
    public Sprite itemIcon; // Icon to represent the item in the UI

    [TextArea(3, 10)]
    public string description;
}
