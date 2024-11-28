using UnityEngine;

public class ChangeLayerOnCollision : MonoBehaviour
{
    private string targetTag = "Lens"; // Tag for the lens GameObject
    private string clickableLayer = "Default";
    private string ignoreRaycastLayer = "Ignore Raycast";

    private string spriteType = "";

    private void Awake()
    {
        if (GetComponent<ItemSprite>() != null)
        {
            spriteType = "Item";
        }
        else if (GetComponent<CharacterSprite>() != null)
        {
            spriteType = "Character";
        }
        SetLayer(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the correct tag
        if (other.CompareTag(targetTag))
        {
            SetLayer(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the layer when the lens stops colliding
        if (other.CompareTag(targetTag))
        {
            SetLayer(false);
        }
    }

    private void SetLayer(bool lensActive)
    {
        if ((lensActive && spriteType == "Item") || (!lensActive && spriteType == "Character"))
        {
            gameObject.layer = LayerMask.NameToLayer(ignoreRaycastLayer);
        }
        else if ((lensActive && spriteType == "Character") || (!lensActive && spriteType == "Item"))
        {
            gameObject.layer = LayerMask.NameToLayer(clickableLayer);
        }
    }
}
