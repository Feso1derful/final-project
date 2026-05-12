using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    int currentHealth;

    public Slider healthBar;
    public GameObject gameOverScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }

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
        currentHealth = Mathf.Max(currentHealth, 0);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player died");

            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}