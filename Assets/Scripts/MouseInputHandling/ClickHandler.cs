using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public LayerMask clickableLayer; // Assign only the clickable layer(s) here

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // Convert the mouse position to world point
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get all hits under the cursor position
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero, Mathf.Infinity, clickableLayer);

            if (hits.Length > 0)
            {
                // Sort the hits by distance from the camera to get the topmost object
                System.Array.Sort(hits, CompareBySortingOrder);

                // Get the topmost hit that has an IClickable component
                foreach (RaycastHit2D hit in hits)
                {
                    CharacterSprite character = hit.collider.GetComponent<CharacterSprite>();
                    if (character != null)
                    {
                        IClickable clickable = hit.collider.GetComponent<IClickable>();
                        clickable.OnClick();
                        return; // Stop after the first topmost clickable object
                    }
                }

                foreach (RaycastHit2D hit in hits)
                {
                    IClickable clickable = hit.collider.GetComponent<IClickable>();
                    if (clickable != null)
                    {
                        clickable.OnClick();
                        return; // Stop after the first topmost clickable object
                    }
                }
            }
        }
    }

    private int CompareBySortingOrder(RaycastHit2D hit1, RaycastHit2D hit2)
    {
        // Get the SpriteRenderer component for each hit
        SpriteRenderer sprite1 = hit1.collider.GetComponent<SpriteRenderer>();
        if (sprite1 == null)
        {
            sprite1 = hit1.collider.GetComponentInChildren<SpriteRenderer>();
        }
        SpriteRenderer sprite2 = hit2.collider.GetComponent<SpriteRenderer>();
        if (sprite2 == null)
        {
            sprite2 = hit1.collider.GetComponentInChildren<SpriteRenderer>();
        }

        // If either sprite is missing, consider it lower in order (optional fallback)
        if (sprite1 == null || sprite2 == null)
            return 0;

        // Compare by sortingOrder (higher sortingOrder is on top)
        return sprite2.sortingOrder.CompareTo(sprite1.sortingOrder);
    }
}
