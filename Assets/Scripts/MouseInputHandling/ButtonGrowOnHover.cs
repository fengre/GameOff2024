using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonGrowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public float hoverScaleMultiplier = 1.2f; // Scale multiplier for the hover effect
    public float transitionSpeed = 10f; // Speed of the scaling transition
    private Vector3 originalScale;
    private bool isHovered = false;

    void Start()
    {
        // Store the original scale of the button
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Smoothly transition to the target scale
        Vector3 targetScale = isHovered ? originalScale * hoverScaleMultiplier : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Trigger hover effect
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert hover effect
        isHovered = false;
    }
}
