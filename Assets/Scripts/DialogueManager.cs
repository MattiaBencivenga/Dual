using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public int wait;
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    private Queue<string> names;
    public Animator animator;
    private PlayerMovement thePlayer;
    public Animator blackTransition;
    public bool firstScene;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        //thePlayer = FindObjectOfType<PlayerMovement>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
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
        yield return new WaitForSeconds(wait);
        DisplaySentence();
    }

    void EndDialogue()
    {
        if (firstScene)
            blackTransition.SetTrigger("Start");
        //thePlayer.canMove = true;
        animator.SetBool("IsOpen", false);
    }
}
