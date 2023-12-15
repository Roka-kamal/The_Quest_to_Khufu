using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_effectBat : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodedBlock;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Your Update logic (if needed)
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collision is with the Player and if the contact point is below the brick
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.y < transform.position.y)
        {
            ExplodeBrick();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Assuming the collider is set to "Is Trigger" and the Player has a Rigidbody2D
        if (other.gameObject.tag == "Player")
        {
            ExplodeBrick();
        }
    }

    void ExplodeBrick()
    {
        // Change the sprite to the explodedBlock sprite
        sr.sprite = explodedBlock;

        // Destroy the GameObject after a delay (0.5 seconds in this case)
        Destroy(gameObject, 0.5f);
    }
}


