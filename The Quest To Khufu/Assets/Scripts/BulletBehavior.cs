using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 10f; // Adjust the speed of the bullet
    public float bulletLifetime = 1f; // Adjust the lifetime of the bullet
    public int bulletDamage = 10; // Adjust the damage caused by the bullet

    void Start()
    {
        // Set the initial velocity to move the bullet to the left
        GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0f);
    }

    void Update()
    {
        // Reduce the lifetime of the bullet
        bulletLifetime -= Time.deltaTime;

        // Check if the bullet's lifetime has expired
        if (bulletLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collides with the player
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerHealth component of the player
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            // Check if the PlayerHealth component is not null
            if (playerHealth != null)
            {
                // Deal damage to the player
                playerHealth.TakeDamage(bulletDamage);

                // Destroy the bullet
                Destroy(gameObject);
            }
        }
    }
}
