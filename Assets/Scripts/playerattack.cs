using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 1;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}