using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public int attackDamage = 1;
    private Enemies closestEnemy;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.R))
        {
            InteractWithClosestEnemy();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackClosestEnemy();
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

    void InteractWithClosestEnemy()
    {
        if (closestEnemy != null)
        {
            closestEnemy.Action();
        }
    }

    void AttackClosestEnemy()
    {
        if (closestEnemy != null)
        {
            closestEnemy.TakeDamage(attackDamage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Enemies enemy = other.GetComponent<Enemies>();
        if (enemy != null)
        {
            closestEnemy = enemy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Enemies enemy = other.GetComponent<Enemies>();
        enemy.Inaction();
        if (enemy != null && enemy == closestEnemy)
        {
            closestEnemy = null;
        }
    }
}
