using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damagePerHit = 1; // Adjust the damage the player deals per hit

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // Check if the enemyHealth is not null
            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.TakeDamage(damagePerHit);
            }
        }
    }
}
