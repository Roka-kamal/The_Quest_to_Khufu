using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public float jumpHeight;
    public KeyCode Spacebar;
    public float jumpDelay = 1f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    public bool isFacingRight;
     private Animator anim;
    public GameObject player; // Assign the main character from the Unity Inspector
    public float followDistance; // The distance the NPC should follow the player
    public float speed; // The speed at which the NPC should follow the player

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        float horizontalDistance = player.transform.position.x - transform.position.x;
        float verticalDistance = player.transform.position.y - transform.position.y;

        // Check if the player is within the follow distance
        if (Mathf.Abs(horizontalDistance) > followDistance)
        {
            // If the player is to the right of the NPC, move right
            if (horizontalDistance > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                if (isFacingRight == false)
                {
                    flip();
                    isFacingRight = true;
                }
            }
            // If the player is to the left of the NPC, move left
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
                if (isFacingRight == true)
                {
                    flip();
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
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
                //Single jump

            }
            // If the player is below the NPC, move down
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -speed);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            StartCoroutine(Jump(jumpDelay));
        }

        anim.SetBool("Grounded", grounded);
         anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }
    IEnumerator Jump(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

}