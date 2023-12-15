using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class walkingEnemy : Enemy_controller
{
    public float ChangeDirectionInterval; // Time interval to change direction in seconds
    private float timeSinceLastDirectionChange;
    private bool isMovingRight = true;

    void Start()
    {
        timeSinceLastDirectionChange = 0f;
    }

    void FixedUpdate()
    {
        // Check if it's time to change direction
        timeSinceLastDirectionChange += Time.deltaTime;
        if (timeSinceLastDirectionChange >= ChangeDirectionInterval)
        {
            // Change direction
            isMovingRight = !isMovingRight;

            // Use the inherited Flip() method from the base class
            Flip();

            // Reset the timer
            timeSinceLastDirectionChange = 0f;
        }
        if (isFacingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }



}
