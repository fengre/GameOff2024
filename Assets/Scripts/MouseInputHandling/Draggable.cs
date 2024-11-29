using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IClickable
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnClick()
    {
        isDragging = true;
    }

    void OnMouseDown()
    {
        // Allow dragging only if the object is the topmost under the mouse pointer
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition + offset;
            PlayerData.LensPosition = transform.position;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
