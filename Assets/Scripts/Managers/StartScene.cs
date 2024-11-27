using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public SpriteRenderer background;
    public Character[] startDialogues;

    private int index = 0;

    private void Start()
    {
        Character c = startDialogues[index];
        background.sprite = c.idleImage;
        dialogueUI.ShowPanel(c, false, false);

        dialogueUI.EndDialogueEvent += DialogueUI_EndDialogueEvent;
    }

    private void DialogueUI_EndDialogueEvent(object sender, System.EventArgs e)
    {
        if (index + 1 < startDialogues.Length)
        {
            index++;
            Character c = startDialogues[index];
            background.sprite = c.idleImage;
            dialogueUI.ShowPanel(c, false, false);
        }
        else
        {
            SceneManagement.Instance.PlayGame();
        }
    }
}
