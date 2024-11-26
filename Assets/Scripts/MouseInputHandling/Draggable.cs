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
        Debug.Log("on click, set dragging");
        isDragging = true;
    }

    void OnMouseDown()
    {
        // Allow dragging only if the object is the topmost under the mouse pointer
        Debug.Log("on mouse down");
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        Debug.Log("on mouse drag");
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition + offset;
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
