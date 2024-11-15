using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretUI : MonoBehaviour
{
    [SerializeField] private Image secretImage;
    [SerializeField] private GameObject secretUIPanel;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(ClosePanel);
        ClosePanel();
    }

    public void ShowPanel(Sprite image)
    {
        secretImage.sprite = image;
        secretUIPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        secretUIPanel.SetActive(false);
    }
}
