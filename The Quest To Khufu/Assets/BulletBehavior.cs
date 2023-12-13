using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 10f; // Adjust the speed of the bullet
    public float bulletLifetime = 4f; // Adjust the lifetime of the bullet

    void Update()
    {
        if (target != null)
        {
            // Move towards the target
            transform.position = Vector2.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
        }

        // Reduce the lifetime of the bullet
        bulletLifetime -= Time.deltaTime;

        // Check if the bullet's lifetime has expired
        if (bulletLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

