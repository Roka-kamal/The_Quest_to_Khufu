using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyingEnemy : Enemy_controller
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Amplitude;

    private Vector3 tempPosition;

    void Start()
    {
        tempPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Move the enemy in a sine wave pattern
        tempPosition.x += HorizontalSpeed * Time.deltaTime;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;

        // Move the enemy
        transform.position = tempPosition;
    }
}
