using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    private PlayerMovement thePlayer;
    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        thePlayer.canMove = false;
    }
}
