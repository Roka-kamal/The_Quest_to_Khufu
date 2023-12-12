using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Variables
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
        grounded=true;
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Single jump
        if(Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }


        if(Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity= new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(isFacingRight==true)
            {
                flip();
                isFacingRight=false;
            }
        }
        
        if(Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity= new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(isFacingRight==false)
            {
                flip();
                isFacingRight=true;
            }
        }

        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));        
                
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity=new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //Audio_Manager.instance.Randomizesfx(jump1,jump2);
    }
     void flip()
     {
        transform.localScale = new Vector3(-(transform.localScale.x),transform.localScale.y,transform.localScale.z);
     }  
 
}
