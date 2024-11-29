using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickupUI : MonoBehaviour
{
    [SerializeField] private GameObject itemPickupUIPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button collectButton;
    [SerializeField] private Button viewButton;
    [SerializeField] private SecretUI secretUI;

    private void Awake()
    {
        collectButton.onClick.AddListener(Hide);
        Hide();
    }

    private void Hide()
    {
        itemPickupUIPanel.SetActive(false);
    }

    public void ShowPanel(Item item)
    {
        itemNameText.text = item.itemName;
        itemImage.sprite = item.itemIcon;
        itemPickupUIPanel.SetActive(true);
        
        if (item is Secret)
        {
            Secret secret = item as Secret;
            viewButton.gameObject.SetActive(true);
            viewButton.onClick.RemoveAllListeners();
            viewButton.onClick.AddListener(() => ShowMemory(secret.secretImages));
        }
        else
        {
            viewButton.gameObject.SetActive(false);
        }
    }

    public void ShowMemory(Sprite[] secretImages)
    {
        secretUI.ShowPanel(secretImages);
    }
}
