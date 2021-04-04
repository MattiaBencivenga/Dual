using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite spriteA;
    public Sprite spriteB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<SpriteRenderer>().sprite = spriteA;
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            GetComponent<SpriteRenderer>().sprite = spriteB;
        }
    }
}
