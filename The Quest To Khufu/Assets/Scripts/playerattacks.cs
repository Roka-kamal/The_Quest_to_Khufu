using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattacks : MonoBehaviour
{
    public int damage = 10; // Adjust the damage amount as needed

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enime"))
        {
            // The collided object is the player, deal damage
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}