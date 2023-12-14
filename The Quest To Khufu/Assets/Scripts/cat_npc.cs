using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_npc : MonoBehaviour
{
    public float flyingHeight;
    public Transform player;
    public float followDistance;
    public float flyingSpeed;
    private Animator anim;
    public bool isFacingRight;

    private void FixedUpdate()
    {
        float horizontalDistance = player.position.x - transform.position.x;
        float verticalDistance = player.position.y - transform.position.y;

        // Check if the player is within the follow distance
        if (Mathf.Abs(horizontalDistance) > followDistance)
        {
            // If the player is to the right of the NPC, move right
            if (horizontalDistance > 0)
            {
                transform.Translate(Vector2.right * flyingSpeed * Time.fixedDeltaTime);
                if (!isFacingRight)
                {
                    Flip();
                    isFacingRight = true;
                }
            }
            // If the player is to the left of the NPC, move left
            else
            {
                transform.Translate(Vector2.left * flyingSpeed * Time.fixedDeltaTime);
                if (isFacingRight)
                {
                    Flip();
                    isFacingRight = false;
                }
            }
        }

        // Check if the player is within the follow distance vertically
        if (Mathf.Abs(verticalDistance) > followDistance)
        {
            // If the player is above the NPC, move up
            if (verticalDistance > 0)
            {
                transform.Translate(Vector2.up * flyingSpeed * Time.fixedDeltaTime);
            }
            // If the player is below the NPC, move down
            else
            {
                transform.Translate(Vector2.down * flyingSpeed * Time.fixedDeltaTime);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("NPC");
        anim = GetComponent<Animator>();
    }

   void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.x));

        // Add other animations or logic based on your game's requirements
    }
    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
