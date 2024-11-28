using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public AudioClip typingSound; // Sound effect for typing
    public float typingSpeed = 0.05f; // Speed of typing

    private Queue<string> dialogueQueue; // Queue for multiple lines of dialogue
    private Queue<AudioClip> audioQueue;
    private AudioSource audioSource; // For playing typing sounds
    private bool isTyping = false; // Whether currently typing
    private bool skipTyping = false; // Flag to skip typing animation

    private void Start()
    {
        dialogueQueue = new Queue<string>();
        audioQueue = new Queue<AudioClip>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Starts the dialogue sequence with an array of lines.
    /// </summary>
    /// <param name="lines">Array of dialogue lines to display.</param>
    public void StartDialogue(string[] lines, AudioClip[] audioClips)
    {
        dialogueQueue.Clear();
        audioQueue.Clear();

        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        if (audioClips != null)
        {
            //Fill audioQueue with clips or nulls to match the number of dialogue lines
            for (int i = 0; i < lines.Length; i++)
            {
                audioQueue.Enqueue(i < audioClips.Length ? audioClips[i] : null);
            }
        }
        else
        {
            //If no audioClips array is provided, fill the queue with nulls
            for (int i = 0; i < lines.Length; i++)
            {
                audioQueue.Enqueue(null);
            }
        }

        DisplayNextLine();
    }

    /// <summary>
    /// Displays the next line in the queue.
    /// </summary>
    public int DisplayNextLine()
    {
        if (isTyping)
        {
            // If typing, skip to show the full line
            skipTyping = true;
            return 2;
        }

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return 0;
        }

        string nextLine = dialogueQueue.Dequeue();

        AudioClip nextClip = (audioQueue != null && audioQueue.Count > 0) ? audioQueue.Dequeue() : null;

        if (nextClip != null)
        {
            audioSource.clip = nextClip;
            audioSource.Play();
        }


        StartCoroutine(TypeText(nextLine));
        return 1;
    }

    /// <summary>
    /// Types out the given text character by character.
    /// </summary>
    /// <param name="text">Text to type out.</param>
    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            if (skipTyping)
            {
                dialogueText.text = text; // Show full text instantly
                break;
            }

            dialogueText.text += letter;

            // Play typing sound
            if (typingSound != null)
            {
                audioSource.PlayOneShot(typingSound);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        skipTyping = false;
    }

    /// <summary>
    /// Ends the dialogue sequence.
    /// </summary>
    private void EndDialogue()
    {
        dialogueText.text = ""; // Clear text or trigger another action
    }
}
