using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecretTree : MonoBehaviour
{
    [Header("Glow info")]
    public Image circleImage;
    public Color glowColor;
    private Color originalColor;
    public float glowDuration;
    public float fadeSpeed;

    [Header("Counter info")]
    public TMP_Text counterText;
    private int clickCount = 0;
    private bool isAnimating = false;
    private const int maxSecrets = 5;

    public GameObject endGameButton;

    [Header("Secrets")]
    public List<Item> secretItems; 

    public void Start()
    {
        originalColor = circleImage.color;
        UpdateCounterText();

        if(endGameButton != null)
        {
            endGameButton.SetActive(false);
        }
    }

    public void OnTreeClicked()
    {
        //Check if animating, if true ignore clicks
        if(isAnimating || clickCount >= maxSecrets)
        {
            return;
        }

        Item secret = GetAvailableSecret();
        if(secret != null)
        {
            Inventory.Instance.RemoveItem(secret);
            Debug.Log("Secret offered to tree.");

            StartCoroutine(GlowEffect());

            clickCount++;
            UpdateCounterText();

            if(clickCount >= maxSecrets && endGameButton != null)
            {
                endGameButton.SetActive(true);
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

    private IEnumerator GlowEffect()
    {
        isAnimating = true;

        //Glow fades out
        float timer = 0f;
        while (timer < glowDuration / 2)
        {
            timer += Time.deltaTime * fadeSpeed;
            float alpha = Mathf.Lerp(glowColor.a, originalColor.a, timer / (glowDuration / 2));
            circleImage.color = new Color(glowColor.r, glowColor.g, glowColor.b, alpha);
            yield return null;
        }

        //Glow fades in
        timer = 0f;
        while(timer < glowDuration / 2)
        {
            timer += Time.deltaTime * fadeSpeed;
            float alpha = Mathf.Lerp(originalColor.a, glowColor.a, timer / (glowDuration / 2));
            circleImage.color = new Color(glowColor.r, glowColor.g, glowColor.b, alpha);
            yield return null;
        }

        //Make sure color is set back to original
        circleImage.color = originalColor;
        isAnimating = false;
    }

    private void UpdateCounterText()
    {
        if(counterText != null)
        {
            counterText.text = "Secrets received: " + clickCount;
        }
    }
}

