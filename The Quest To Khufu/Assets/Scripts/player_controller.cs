using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Variables
    public KeyCode SlideKey; // Add a key for sliding
    public float slideDuration; // Duration of the slide
    private bool isSliding;
    private float slideTimer;
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    public bool isFacingRight;
    private Animator anim;

    public AudioClip jump1;
    public AudioClip jump2;

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Single jump
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }


        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight == true)
            {
                flip();
                isFacingRight = false;
            }
        }

        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight == false)
            {
                flip();
                isFacingRight = true;
            }
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));


        if (Input.GetKeyDown(SlideKey) && grounded && !isSliding)
        {
            Vector2 direction = new Vector2(isFacingRight ? 1 : -1, 0);
            float rotationZ = isFacingRight ? 90 : -90;
            StartSlide(direction, rotationZ);
        }
        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0)
            {
                StopSlide();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            // Ignore collision with the player
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //Audio_Manager.instance.Randomizesfx(jump1,jump2);
    }
    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }


    void StartSlide(Vector2 direction, float rotationZ)
    {
        isSliding = true;
        slideTimer = slideDuration;

        // Adjust the collider or other properties for sliding, e.g., decrease collider height
        // You may need to adjust this based on your character's specific setup
        // For example, if you're using a BoxCollider2D:
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(collider.size.x, collider.size.y * 0.5f);

        // You may also want to adjust other properties like moveSpeed for sliding
        // e.g., decrease moveSpeed while sliding
        moveSpeed /= 2.0f;
        // Set the z rotation based on the direction vector
        transform.eulerAngles = new Vector3(0, 0, rotationZ);
        // Stop the animation
        anim.enabled = false;
    }
    void StopSlide()
    {
        isSliding = false;

        // Reset properties that were adjusted during sliding
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(collider.size.x, collider.size.y * 2.0f);

        // Reset moveSpeed or other properties if needed
        moveSpeed *= 2.0f;
        // Set the z rotation back to 0 after sliding
        transform.eulerAngles = new Vector3(0, 0, 0);
        // Start the animation again
        anim.enabled = true;
    }

}