using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ChracterSprite : MonoBehaviour, IClickable
{
    public Character character;  // Assign the Character asset in the Inspector
    public DialogueUI dialogueUI;
    private bool hasReceivedItem = false;
    


    public void OnClick()
    {
        
        bool firstShow = false;
        if (!hasReceivedItem && Inventory.Instance.ContainsItem(character.desiredItem)) {
            GiveItem();
            GetSecret();
            firstShow = true;
        }
        
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
