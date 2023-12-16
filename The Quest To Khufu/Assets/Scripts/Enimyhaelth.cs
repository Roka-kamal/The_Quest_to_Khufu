using UnityEngine;
using UnityEngine.SceneManagement;

public class Enimyhaelth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if health is zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Load the Victory scene
        SceneManager.LoadScene("gotovictoryscene");
    }
}
