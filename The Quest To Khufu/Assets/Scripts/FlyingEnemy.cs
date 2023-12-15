using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Amplitude;
    public float ChangeDirectionInterval; // Time interval to change direction in seconds

    private Vector3 tempPosition;
    private float timeSinceLastDirectionChange;
    private bool isMovingRight = true;

    void Start()
    {
        tempPosition = transform.position;
        timeSinceLastDirectionChange = 0f;
    }

    void FixedUpdate()
    {
        // Move the enemy in a sine wave pattern
        tempPosition.x = transform.position.x + (isMovingRight ? 1 : -1) * HorizontalSpeed * Time.deltaTime;
        tempPosition.y = Mathf.Sin(Time.time * VerticalSpeed) * Amplitude;

        // Move the enemy
        transform.position = tempPosition;

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
    }


}