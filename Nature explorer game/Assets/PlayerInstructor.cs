using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructor : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
    }
}
