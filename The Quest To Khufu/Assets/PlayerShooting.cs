using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; // The position where the bullets will be spawned
    public GameObject bulletPrefab; // The bullet prefab
    public float bulletSpeed = 10f; // Speed of the bullets

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply force to the bullet to make it move straight up
        rb.velocity = transform.up * bulletSpeed;
    }
}
