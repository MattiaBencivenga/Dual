using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DestroyCutscene : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject bro;
    public GameObject newscene;
    public GameObject dialogue;
    public AudioSource paper;
    public void DestroyTimeline()
    {
        Destroy(cutscene);
        Destroy(bro);
        Destroy(dialogue);
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
