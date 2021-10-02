using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject canvas;

    private PlayerMovement thePlayer;
    private Animator playerAnimator;

    public Animator animator;
    public Animator Transition;
    public bool playTransition;
    
    public StartDialogue current_dialogue;

    public bool playSound;
    public AudioSource sound;
    private Queue<string> sentences;
    private Queue<string> names;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerAnimator = thePlayer.GetComponent<Animator>();
        sentences = new Queue<string>();
        names = new Queue<string>();
        //thePlayer = FindObjectOfType<PlayerMovement>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerAnimator.SetInteger("Idle", 0);
        playerAnimator.SetFloat("Speed", 0.0f);
        thePlayer.enabled = false;
        canvas.SetActive(true);
        animator.SetBool("IsOpen", true);
        names.Clear();
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach(string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (sentences.Count==0 && animator.GetBool("IsOpen"))
        {
            EndDialogue();
            return;
        }
        if (playSound && sound != null && sentences.Count == 2)
            sound.Play();
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence(string sentence, string name)
    {
        dialogueText.text = "";
        nameText.text = "";
        foreach (char letter in name.ToCharArray())
        {
            nameText.text += letter;
            yield return null;
        }
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        //yield return new WaitForSeconds(wait);
        //DisplaySentence();
    }

    public void EndDialogue()
    {
        Debug.Log("End DIalogue");
        if (playTransition)
            Transition.SetTrigger("Start");
        canvas.SetActive(false);
        //thePlayer.canMove = true;
        animator.SetBool("IsOpen", false);
        thePlayer.enabled = true;
        //reset dialogue
        if (current_dialogue != null)
            current_dialogue._hasToStart = true;
    }
}
