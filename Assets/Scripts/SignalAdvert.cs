using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalAdvert : MonoBehaviour
{
    public GameObject noticeText;
    private Text text;

    void Start()
    {
        text = noticeText.GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
            text.enabled = true;
    }

    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
            text.enabled = false;
    }
}
