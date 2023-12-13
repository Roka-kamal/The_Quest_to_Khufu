using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetPosition; // The position the enemy will move towards
    public float moveSpeed = 5f; // The speed at which the enemy moves

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        // Check if the enemy has reached the target position
        if ((Vector2)transform.position != (Vector2)targetPosition.position)
        {
            // Move towards the target position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
        }
    }
}
