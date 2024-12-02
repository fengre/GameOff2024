using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScene : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public Character initialTreeDialogue;
    public Character withSecretDialogue;

    private void Start()
    {
        if (PlayerData.CollectedSecrets.Count > 0)
        {
            dialogueUI.ShowPanel(withSecretDialogue, false, false);
        }
        else
        {
            dialogueUI.ShowPanel(initialTreeDialogue, false, false);
        }
    }
}
