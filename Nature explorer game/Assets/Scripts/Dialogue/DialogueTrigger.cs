using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogueManager dialogueManager;

    public void TriggerDialogue()
    {
        dialogueManager = DialogueManager.instance;
        dialogueManager.StartDialogue(dialogue);
    }
}
