using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent : MonoBehaviour
{
    private bool collision = false;
    private bool completed = false;
    public GameObject chimneyConversation;
    //public GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
            collision = true;


        //if (plyr.gameObject.tag == "Player")
            //text.enabled = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collision)
        {
            if (!completed)
            {
                completed = !completed;
                chimneyConversation.SetActive(true);
                //stopPlayer.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
            collision = false;
    }
}
