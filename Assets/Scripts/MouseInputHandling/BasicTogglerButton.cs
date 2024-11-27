using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicTogglerButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject toggledGO;

    private void Awake()
    {
        button.onClick.AddListener(ToggleGO);
    }

    private void ToggleGO()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.onClickSFX);
        toggledGO.SetActive(!toggledGO.activeSelf);
    }
}
