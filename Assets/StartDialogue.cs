using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartDialogue : Interactable
{
    public DialogueTrigger trigger;
    public DialogueManager dialogueManager;
    public bool _hasToStart = true;
    public bool chimney;
    override public void Interact()
    {
        dialogueManager.current_dialogue = this;

        if (_hasToStart == true)
        {
            trigger.TriggerDialogue();
            _hasToStart = false;
        }
        else
        {
            dialogueManager.DisplaySentence();
        }
    }

    new private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //dialogueManager.EndDialogue();
            _hasToStart = true;
            isColliding = false;
            /*if (chimney)
                SceneManager.LoadScene(2);*/
        }
    }
}