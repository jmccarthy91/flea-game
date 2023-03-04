using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public UnitHealth _enemyHealth = new UnitHealth(100, 100);
    public float moveSpeed = 4f;
    public float attackDamage = 50f;
    
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
        target = GameObject.Find("Player").transform;               // Clean this up later - apparently can target based upon layer?
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

    private void EnemyTakeDmg(float dmg)
    {
        GameManager.gameManager._enemyHealth.DmgUnit(dmg);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameEvents.gameEvents.EnemyCollision(attackDamage);
            Destroy(gameObject);
        }
    }
}

