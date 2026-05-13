using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 1;

    SpriteRenderer sr;
    Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // FLASH EFFECT
        sr.color = Color.red;
        Invoke(nameof(ResetColor), 0.1f);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D hit in hits)
        {
            EnemySwarmHealth enemy = hit.GetComponentInParent<EnemySwarmHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}