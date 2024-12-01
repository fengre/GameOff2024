using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecretTree : MonoBehaviour
{
    [Header("Counter info")]
    private static int clickCount = 0;
    private const int maxSecrets = 5;

    public GameObject endGameButton;

    [Header("Secrets")]
    public List<Item> secretItems;

    [Header("Tree Secret Images")]
    public Image greenSecretImage;
    public Image purpleSecretImage;
    public Image redSecretImage;
    public Image whiteSecretImage;
    public Image yellowSecretImage;

    public void Start()
    {
        if(endGameButton != null)
        {
            endGameButton.SetActive(false);
        }

        foreach (string color in PlayerData.PlacedSecrets)
        {
            ActivateColorImage(color);
        }
    }

    public void OnTreeClicked()
    {
        if(clickCount >= maxSecrets)
        {
            return;
        }

        Item secret = GetAvailableSecret();
        if(secret != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectSFX);
            Inventory.Instance.RemoveItem(secret);
            Debug.Log("Secret offered to tree.");

            ActivateColorImage(secret.color);
            PlayerData.PlacedSecrets.Add(secret.color);

            clickCount++;

            if(clickCount >= maxSecrets)
            {
                if (SceneManagement.Instance != null)
                {
                    SceneManagement.Instance.LoadSceneByName("EndScene");
                }
                else
                {
                    Debug.LogWarning("SceneManagement instance not found!");
                }
            }
        }
        else
        {
            Debug.Log("No secrets in inventory");
        }
    }

    private Item GetAvailableSecret()
    {
        foreach(var secret in secretItems)
        {
            if(Inventory.Instance.ContainsItem(secret))
            {
                return secret;
            }
        }
        return null;
    }

    private void ActivateColorImage(string color)
    {

        switch (color.ToLower())
        {
            case "green":
                greenSecretImage.gameObject.SetActive(true);
                break;
            case "purple":
                purpleSecretImage.gameObject.SetActive(true);
                break;
            case "red":
                redSecretImage.gameObject.SetActive(true);
                break;
            case "white":
                whiteSecretImage.gameObject.SetActive(true);
                break;
            case "yellow":
                yellowSecretImage.gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning($"No image assigned for color: {color}");
                break;
        }
    }

}

