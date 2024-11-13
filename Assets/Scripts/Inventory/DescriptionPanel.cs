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

    private void Start()
    {
        Hide();   
    }

    public void ShowPanel(Item item)
    {
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
        itemImage.sprite = item.itemIcon;
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
