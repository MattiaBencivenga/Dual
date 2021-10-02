using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public GameObject trigger;
    //public GameObject canvas;

    /*void Update()
    {
		if (trigger.activeSelf)
		{
            trigger.SetActive(false);
			TriggerDialogue();
		}
	}*/

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //canvas.SetActive(true);
    }
}
