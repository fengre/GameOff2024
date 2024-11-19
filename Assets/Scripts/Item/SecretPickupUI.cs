using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecretPickupUI : MonoBehaviour
{
    [SerializeField] private GameObject secretPickupUIPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button collectButton;

    private void Awake()
    {
        collectButton.onClick.AddListener(Hide);
        Hide();
    }

    private void Hide()
    {
        secretPickupUIPanel.SetActive(false);
    }

    public void ShowPanel(Item item)
    {
        itemNameText.text = item.itemName;
        itemImage.sprite = item.itemIcon;
        secretPickupUIPanel.SetActive(true);
    }
}