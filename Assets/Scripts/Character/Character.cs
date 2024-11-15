using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    public string characterName;

    [TextArea(3,10)]
    public string initialDialogue;

    public Item desiredItem;

    [TextArea(3,10)]
    public string postItemDialogue;

    public Secret secret;

    // Method to get dialogue based on whether the item has been received
    public string GetDialogue(bool hasReceivedItem)
    {
        return hasReceivedItem ? postItemDialogue : initialDialogue;
    }
}
