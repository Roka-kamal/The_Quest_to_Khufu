using System.Diagnostics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2; // Adjust the maximum health of the enemy
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death-related logic, e.g., play death animation, disable the enemy, etc.
        UnityEngine.Debug.Log("Enemy died!");

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
