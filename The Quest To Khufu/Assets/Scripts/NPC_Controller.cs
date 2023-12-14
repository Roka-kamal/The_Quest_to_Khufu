using System.Collections;
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
    public GameObject player;
    public float followDistance;
    public float speed;

    // Teleportation variables
    public float teleportDistance;
    public float teleportDelay;

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
        gameObject.layer = LayerMask.NameToLayer("NPC");
        grounded = true;
        anim = GetComponent<Animator>();
        StartCoroutine(TeleportCoroutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(Spacebar))
        {
            StartCoroutine(Jump(jumpDelay));
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Allow interaction with the ground
        }
        else
        {
            // Ignore collision with the player
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
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

    private IEnumerator TeleportCoroutine()
    {
        while (true)
        {
            // Check the distance between NPC and player
            float distance = Vector2.Distance(transform.position, player.transform.position);

            // If the NPC is not within the specified distance, initiate teleportation
            if (distance > teleportDistance)
            {
                // Teleport the NPC to the specified distance from the player
                Vector2 teleportPosition = player.transform.position + (transform.position - player.transform.position).normalized * teleportDistance;
                transform.position = teleportPosition;
            }

            yield return new WaitForSeconds(teleportDelay);
        }
    }
}
