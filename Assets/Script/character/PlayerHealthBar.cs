using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar; // Reference to the HealthBar script

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // Set the maximum health in the health bar
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Simulate taking damage
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}