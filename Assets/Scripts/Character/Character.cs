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

    public AudioClip[] initialDialogueAudio; // Add this
    public AudioClip[] postItemDialogueAudio;

    // Method to get dialogue based on whether the item has been received
    public (string[], AudioClip[]) GetDialogueAndAudio(bool hasReceivedItem)
    {
        string[] dialogue = hasReceivedItem ? postItemDialogue : initialDialogue;
        AudioClip[] audio = hasReceivedItem ? postItemDialogueAudio : initialDialogueAudio;

        // Ensure audio array matches the size of the dialogue array
        if (audio == null || audio.Length < dialogue.Length)
        {
            AudioClip[] adjustedAudio = new AudioClip[dialogue.Length];
            for (int i = 0; i < dialogue.Length; i++)
            {
                adjustedAudio[i] = (audio != null && i < audio.Length) ? audio[i] : null;
            }
            audio = adjustedAudio;
        }

        return (dialogue, audio);
    }
}
