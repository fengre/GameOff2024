using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecretTree : MonoBehaviour
{
public static SecretTree Instance {get; private set;}

    [Header("Counter info")]
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

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeDuration = 2.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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
        Item secret = GetAvailableSecret();
        if(secret != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectSFX);
            Inventory.Instance.RemoveItem(secret);
            Debug.Log("Secret offered to tree.");

            ActivateColorImage(secret.color);
            PlayerData.PlacedSecrets.Add(secret.color);

            if (AreAllSecretsActive())
            {
                StartCoroutine(FadeAndLoadScene("EndScene"));
            }
        }
        else
        {
            Debug.Log("No secrets in inventory");
        }
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            Color fadeColor = fadeImage.color;
            fadeColor.a = 0f;
            fadeImage.color = fadeColor;

            float timer = 0f;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                fadeColor.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                fadeImage.color = fadeColor;
                yield return null;
            }
        }

        SceneManagement.Instance.LoadSceneByName(sceneName);
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

    private bool AreAllSecretsActive()
    {
        return greenSecretImage.gameObject.activeSelf &&
            purpleSecretImage.gameObject.activeSelf &&
            redSecretImage.gameObject.activeSelf &&
            whiteSecretImage.gameObject.activeSelf &&
            yellowSecretImage.gameObject.activeSelf;
    }

    public void ResetTree()
    {
        greenSecretImage.gameObject.SetActive(false);
        purpleSecretImage.gameObject.SetActive(false);
        redSecretImage.gameObject.SetActive(false);
        whiteSecretImage.gameObject.SetActive(false);
        yellowSecretImage.gameObject.SetActive(false);

        PlayerData.PlacedSecrets.Clear();

        Debug.Log("Tree has been reset.");
    }
}

