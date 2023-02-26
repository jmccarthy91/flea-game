using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float maxHealth = 100;
    public float moveSpeed = 4f;
    
    float currentHealth;
    Rigidbody2D rigidBody;
    Transform target;
    Vector2 moveDirection;

    
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform; // Clean this up later - apparently can target based upon layer?
    }

    void Update()
    {

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            moveDirection = direction;
            rigidBody.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        if(target)
        {
            rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

