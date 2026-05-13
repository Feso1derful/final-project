using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    int currentHealth;

    public Slider healthBar;
    public GameObject gameOverScreen;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        // ALWAYS hide at start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        // TEST DAMAGE
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("PLAYER DIED");

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // Slight delay before freeze helps UI appear
        Invoke(nameof(FreezeGame), 0.1f);
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
    }
}