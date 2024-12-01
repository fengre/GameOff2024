using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemPickupUI : MonoBehaviour
{
    [SerializeField] private GameObject itemPickupUIPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button collectButton;
    [SerializeField] private Button viewButton;
    [SerializeField] private SecretUI secretUI;
    private bool isCollecting = false;

    private void Awake()
    {
        collectButton.onClick.AddListener(() =>
        {
            isCollecting = true; // Set the flag
            Hide();
        });
        Hide();
    }

    private void Hide()
    {
        if (isCollecting)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectSFX);
            isCollecting = false;
        }
        
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
        AudioManager.Instance.PlaySFX(AudioManager.Instance.viewSecretSFX);
        secretUI.ShowPanel(secretImages);
    }
}
