using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject player;
    
    protected bool hasInputUse;
    protected bool isColliding;
    
    abstract public void Interact();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hasInputUse = false;
        isColliding = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isColliding)
            hasInputUse = true;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isColliding = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasInputUse)
            {
                hasInputUse = false;
                Interact();
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isColliding = false;
    }
}
