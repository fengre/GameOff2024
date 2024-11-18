using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button viewButton;
    [SerializeField] private SecretUI secretUI;

    private void Start()
    {
        viewButton.gameObject.SetActive(false);
        Hide();   
    }

    public void ShowPanel(Item item)
    {
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
        itemImage.sprite = item.itemIcon;
        this.gameObject.SetActive(true);

        if (item is Secret)
        {
            Secret secret = item as Secret;
            viewButton.gameObject.SetActive(true);
            viewButton.onClick.AddListener(() => ShowMemory(secret.secretImage));
        }
        else
        {
            viewButton.gameObject.SetActive(false);
        }
        
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowMemory(Sprite secretImage)
    {
        secretUI.ShowPanel(secretImage);
    }
}
