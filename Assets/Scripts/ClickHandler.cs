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
                System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

                // Get the topmost hit that has an IClickable component
                foreach (RaycastHit2D hit in hits)
                {
                    IClickable clickable = hit.collider.GetComponent<IClickable>();
                    if (clickable != null)
                    {
                        clickable.OnClick();
                        break; // Stop after the first topmost clickable object
                    }
                }
            }
        }
    }
}
