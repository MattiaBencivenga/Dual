using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    public float wanderTime;
    public float movementSpeed;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (target == null)
        {
            SearchForTarget();
            if (wanderTime > 0)
            {
                transform.Translate(Vector3.forward * movementSpeed);
                wanderTime -= Time.deltaTime;
            }
            else
            {
                wanderTime = Random.Range(5.0f, 15.0f);
                Wander();
            }
        }
        else
            FollowTarget();
    }

    void SearchForTarget() 
    {
        Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Collider[] hitCollider = Physics.OverlapSphere(center, 100f);
        int i = 0;
        while (i < hitCollider.Length)
        {
            if (hitCollider[i].transform.tag == "Player")
                target = hitCollider[i].transform.gameObject;
            i++;
        }
    }

    void Wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    void FollowTarget()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(target.transform.position, this.transform.position);
        if (distance > 30)
            transform.Translate(Vector3.forward * movementSpeed);
    }

    public void TakeDamage(int damage)
    {
        //animator.SetTrigger("Hurt");
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        //animator.SetBool("IsDead", true);
        GetComponent<Collider>().enabled = false;
        //this.enabled = false;
        Destroy(gameObject);

    }
}
