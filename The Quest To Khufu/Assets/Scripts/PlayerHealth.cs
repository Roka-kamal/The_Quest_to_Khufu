using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int lives = 3;

    public float flickerDuration = 0.1f; // Corrected variable name
    private SpriteRenderer spriteRenderer;
    public int coinsCollected;
    public int keysCollected;
    public int lettersCollected;

    public Slider healthSlider; // Reference to the UI Slider
    public TextMeshProUGUI coins;
    public TextMeshProUGUI livesLeft; // Corrected variable name

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

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

    void Update()
    {
        coins.text = ": " + coinsCollected;
        livesLeft.text = ": " + lives;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Flicker the sprite when taking damage
        SpriteFlicker();

        if (currentHealth <= 0)
        {
            // Player has run out of health, decrement lives and reset health
            lives--;

            if (lives > 0)
            {
                // Player has more lives, reset health
                currentHealth = maxHealth;
                UpdateHealthBar();
            }
            else
            {
                // No more lives, player dies
                Die();
            }
        }
        else
        {
            UpdateHealthBar();

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
        if (gameObject.tag == "enime")
        {
            // Load the Victory scene
            GameManager.instance.gotovictoryscene();
        }
        else
        {
            // For other cases, load the Game Over scene
            GameManager.instance.gotogameover();
        }
    }

    void SpriteFlicker()
    {
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        float flickerTime = 0f;

        while (flickerTime < flickerDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.05f); // Adjusted the waiting time
            flickerTime += 0.05f;
        }

        spriteRenderer.enabled = true; // Ensure the sprite is visible after flickering
    }

    //collected objects
    public void CollectCoin(int coinValue)
    {
        this.coinsCollected += coinValue;
    }

    public void CollectKeys(int key_value)
    {
        this.keysCollected += key_value;
    }

    public void CollectLetter(int letter_value)
    {
        this.lettersCollected += letter_value;
    }
}
