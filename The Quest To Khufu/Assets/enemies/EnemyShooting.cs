using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint; // The position where the bullets will be spawned
    public GameObject bulletPrefab; // The bullet prefab
    public float bulletForce = 10f; // The force applied to the bullet
    public float timeBetweenShots = 2f; // Time between each shot

    private void Start()
    {
        // Start shooting coroutine
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShots);

            // Instantiate a bullet at the firePoint position
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Apply force to the bullet to make it move
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
