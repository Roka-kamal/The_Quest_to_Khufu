using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint; // The position where the bullets will be spawned
    public GameObject bulletPrefab; // The bullet prefab
    public int bulletsPerGroup = 5; // Number of bullets in each group
    public float timeBetweenShots = 5f; // Time between each group of shots
    public float bulletSpeed = 10f; // Speed of the bullets

    public bool isShooting = false;
    private Coroutine shootingCoroutine;

    void Start()
    {
        shootingCoroutine = StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true) // This will continue until the object is destroyed
        {
            yield return new WaitForSeconds(timeBetweenShots);

            // Start shooting a group of bullets in a straight line
            isShooting = true;

            // Spawn bullets in a straight line
            for (int i = 0; i < bulletsPerGroup; i++)
            {
                Shoot();
                yield return new WaitForSeconds(0.1f); // Adjust this delay between bullets in a group
            }

            isShooting = false;
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

    // Optionally, you may want to stop the coroutine when the object is destroyed
    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
