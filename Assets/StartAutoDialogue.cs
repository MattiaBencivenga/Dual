using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAutoDialogue : Interactable
{
    public bool initialConversation;
    public DialogueTrigger trigger;
    public DialogueManager dialogueManager;

    //private bool _dialogueStarted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
        if (other.gameObject == player)
            trigger.TriggerDialogue();
    }

    public override void Interact()
    {
        dialogueManager.DisplaySentence();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //dialogueManager.EndDialogue();
            isColliding = false;
            if (initialConversation)
                Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
