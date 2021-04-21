using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    int status_idle;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.y < 0)
        {
            status_idle = 0;
        }
        if (movement.y > 0)
        {
            status_idle = 1;
        }
        if (movement.x < 0 && movement.y==0)
        {
            status_idle = 2;
        }
        if (movement.x > 0 && movement.y == 0)
        {
            status_idle = 3;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.sqrMagnitude == 0)
            animator.SetInteger("Idle", status_idle);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}
