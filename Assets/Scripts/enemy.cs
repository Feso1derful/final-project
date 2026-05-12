using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 1;

    float attackCooldown = 1.5f;
    float lastAttackTime;

    Transform player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    void Update()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (Time.time - lastAttackTime < attackCooldown) return;

        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            ph.TakeDamage(damage); // still 1 damage
            lastAttackTime = Time.time;
        }
    }
}