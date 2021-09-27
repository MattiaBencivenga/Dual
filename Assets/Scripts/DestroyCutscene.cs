using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DestroyCutscene : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject dialogueBox;
    public GameObject newBox;
    public GameObject newscene;
    public AudioSource paper;
    public void DestroyTimeline()
    {
        cutscene.SetActive(false);
        dialogueBox.SetActive(false);
        newBox.SetActive(true);
    }

    public void StartTimeline()
    {
        newscene.SetActive(true);
    }

    public void PlayPaper()
    {
        paper.Play();
    }
}
