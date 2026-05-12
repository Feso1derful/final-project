using UnityEngine;
using UnityEngine.UI;

public class EnemySwarmHealth : MonoBehaviour
{
    public int maxHealth = 2;
    int currentHealth;

    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthBar != null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        WaveManager wm = FindFirstObjectByType<WaveManager>();

        if (wm != null)
        {
            wm.EnemyDied();
        }
    }
}