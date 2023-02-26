using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float attackRate = 2f;
    public float attackRange = 1.8f;
    public float attackDamage = 50f;

    float nextAttackTime = 0f;
    
    public Rigidbody2D rigidBody;
    public Camera cam;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Get movement inputs
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;

        //Get rotation inputs
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);


        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void FixedUpdate()
    {
        //Move!
        rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;

        //Aim
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }

    void Attack()
    {
        //swing animation
        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);

        //check collision
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //will want to update this to not be a sphere........
        
        //damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            Debug.Log("hit enemy!");
        }
    }

    void OnDrawGizmos()                                                                     // can delete this later
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}