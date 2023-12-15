using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider; // Reference to the UI Slider
    public int coinsCollected = 0;


    void Start()
    {
        currentHealth = maxHealth;

        // Make sure you have assigned the healthSlider reference in the Inspector
        if (healthSlider == null)
        {
            UnityEngine.Debug.LogError("HealthSlider not assigned! Please assign it in the Inspector.");
        }
        else
        {
            // Set the max value of the slider to the player's max health
            healthSlider.maxValue = maxHealth;
            // Set the current value of the slider to the player's current health
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update the UI health bar
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {

            // Add any additional logic for player taking damage, like checking for death
            UnityEngine.Debug.Log("Player took " + damage + " damage. Current Health: " + currentHealth);
        }
    }

    void UpdateHealthBar()
    {
        // Update the value of the health slider to reflect the player's current health
        healthSlider.value = currentHealth;
    }


    void Die()
    {
        // Check if the GameObject has the tag "Enemy"
        if (gameObject.CompareTag("enime"))
        {
            // Load the Victory scene
            GameManager.instance.gotovictoryscene();

        }
        else if (currentHealth <= 0)
        {
            // For other cases, load the Game Over scene
            GameManager.instance.gotogameover();
        }
    }

    public void CollectCoin(int coinValue)
    {
        this.coinsCollected += coinValue;
    }
}
//    void Die()
//    {
//        // Add logic for player death, such as playing a death animation, showing a game over screen, etc.
//        UnityEngine.Debug.Log("Player has died!");
//        gameObject.SetActive(false);
//        GameManager.instance.gotogameover();

//    }
//}