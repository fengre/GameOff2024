using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite idleImage;
    public Sprite speakingImage;
    public Sprite itemReceivedIdleImage;
    public Sprite itemReceivedSpeakingImage;
    public Item desiredItem;
    public Secret secret;

    [TextArea(1,10)]
    public string[] initialDialogue;    

    [TextArea(1,10)]
    public string[] postItemDialogue;

    // Method to get dialogue based on whether the item has been received
    public string[] GetDialogue(bool hasReceivedItem)
    {
        return hasReceivedItem ? postItemDialogue : initialDialogue;
    }
}
