using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences = new Queue<string>();
    public TMPro.TextMeshProUGUI dialogueText;
    
    #region Singleton

	public static DialogueManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of DialogueManager found!");
			return;
		}

		instance = this;
	}

	#endregion

    public void StartDialogue (Dialogue dialogue)
    {
        // Debug.Log("Starting conversation...");

        if(sentences!= null)
        {
            Debug.Log("Clearing sentences...");
            sentences.Clear();
        }

        foreach ( string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; 
        }
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        Debug.Log("Dialogue ended.");
    }

}
