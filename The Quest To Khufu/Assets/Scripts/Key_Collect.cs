using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Collect : MonoBehaviour
{
    public int keyvalue = 10;
    public float floatSpeed = 1.0f; // Adjust the speed of the floating motion
    public float floatMagnitude = 0.5f; // Adjust the magnitude of the floating motion

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the coin up and down using a sinusoidal function
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatMagnitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().keysCollected += keyvalue;
            Destroy(this.gameObject);

        }
    }
}
