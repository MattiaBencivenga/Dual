using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterHome : MonoBehaviour
{
    public GameObject enterText;
    private Text text;
    private bool collision;
    public string levelToLoad;

    void Start()
    {
        text = enterText.GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collision)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            text.enabled = true;
            collision = true;
        }
    }

    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            text.enabled = false;
            collision = false;
        }
    }
}
