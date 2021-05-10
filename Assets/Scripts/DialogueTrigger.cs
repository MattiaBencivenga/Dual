using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject button;
    public GameObject canvas;
    // Start is called before the first frame update
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        button.SetActive(false);
        canvas.SetActive(true);
    }
}
