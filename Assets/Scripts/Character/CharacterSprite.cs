using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CharacterSprite : MonoBehaviour, IClickable
{
    public DialogueManager dialogueManager;
    public Character character;  // Assign the Character asset in the Inspector
    public DialogueUI dialogueUI;
    public SpriteRenderer characterImage;
    private bool hasReceivedItem = false;

    private void Awake()
    {
        dialogueManager.EndDialogueEvent += DialogueManager_EndDialogueEvent;
    }

    private void DialogueManager_EndDialogueEvent(object sender, System.EventArgs e)
    {
        characterImage.sprite = character.idleImage;
    }

    public void OnClick()
    {
        bool firstShow = false;
        if (!hasReceivedItem && Inventory.Instance.ContainsItem(character.desiredItem)) {
            GiveItem();
            GetSecret();
            firstShow = true;
        }
        
        characterImage.sprite = character.speakingImage;
        dialogueUI.ShowPanel(character, hasReceivedItem, firstShow);
    }

    private void GiveItem()
    {
        hasReceivedItem = true;
        Inventory.Instance.RemoveItem(character.desiredItem);
    }

    private void GetSecret()
    {
        Inventory.Instance.AddItem(character.secret);
    }
}

