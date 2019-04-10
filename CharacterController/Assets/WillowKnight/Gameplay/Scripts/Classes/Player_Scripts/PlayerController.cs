using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    float dirX;

    //determines base jump force and movement speed
    float jumpForce = 1000f, moveSpeed = 15f;
    
    
    Rigidbody2D rb;

    //aircheck
    bool doubleJumpAllowed = false;

    //groundcheck
    bool onTheGround = false;

    //wallcheck
    private bool WallSlidingR = false;
    private bool WallSlidingL = false;

    //direction check
    private bool FacingRight;

    //particle effects for when the player takes damage and dies, not currently in use
    public GameObject LightBlood;
    public GameObject LightBlast;

    //assigns the player a healthbar, not currently in use
    public Slider HealthBar;

    //assigns a public transform of an empty that acts as a wallcheck
    public Transform wallCheckR;
    public Transform wallCheckL;

    //shoots a raycast that determines if the player is making contact with a wall or not
    public float wallCheckDistanceR;
    public float wallCheckDistanceL;

    //determines how fast the player will slide down a given wall
    public float maxWallSlideVel;

    //determines the force at which a player is able to jump off of a wall
    public float wallJumpForce;

    public int PlayerHealth;

    private RaycastHit2D wallCheckHitR;
    private RaycastHit2D wallCheckHitL;

    public Animator animator;

   


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FacingRight = false;
        
    }

    // Update is called once per frame

    //     UNUSED ANIMATORS
    //   animator.SetBool("IsJumping", false);
    //   animator.SetBool("IsFalling", false);

    //Double Jump Code


  
  

    void Update()
    {

        if (rb.velocity.y == 0)
        {
            onTheGround = true;

            Debug.Log("fug");
        }

        else
            onTheGround = false;
        //   animator.SetBool("IsFalling", true);

        if (onTheGround)
        {
            doubleJumpAllowed = true;

        }


        if (onTheGround && Input.GetButtonDown("Jump"))
        {
            Jump();

            //animator.SetBool("IsJumping", true);

        }

        else if (doubleJumpAllowed && Input.GetButtonDown("Jump"))
        {
            Jump();
            doubleJumpAllowed = false;

            //   animator.SetBool("IsJumping", true);

        }

        //   animator.SetBool("IsFalling", false);

        //movement


        //animates walking movement

        animator.SetFloat("GroundMovement", Mathf.Abs(dirX));

        //flips sprite animation

        if (dirX > 0 && !FacingRight || dirX < 0 && FacingRight)
        {
            FacingRight = !FacingRight;

            Vector2 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }

        //checks for a surface to the immediate right or left of the player
        wallCheckHitR = Physics2D.Raycast(wallCheckR.position, wallCheckR.right, wallCheckDistanceR);


        wallCheckHitL = Physics2D.Raycast(wallCheckL.position, -wallCheckL.right, wallCheckDistanceL);

        //prints wallhit into the console 
        if (wallCheckHitR)
        {
            Debug.Log("wallhit");
        }



        //checks for wall contact and then turns on wallslide if there is contact
        if (wallCheckHitR && rb.velocity.y <= 0 && !onTheGround)
        {
            WallSlidingRight();

        }

        else
        {
            WallSlidingR = false;
        }


        if (wallCheckHitL)
        {
            Debug.Log("killme");
        }

        if (wallCheckHitL && rb.velocity.y <= 0 && !onTheGround)
        {
            WallSlidingLeft();

        }

        else
        {
            WallSlidingL = false;
        }

   
    }

    private void FixedUpdate()
    {

            dirX = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        
    }

   

    void WallSlidingRight()
    {
       
            if (rb.velocity.y < -maxWallSlideVel)
            {
                rb.velocity = new Vector2(0, -maxWallSlideVel);
            }

    }

    void WallSlidingLeft()
    {

            if (rb.velocity.y < -maxWallSlideVel)
            {
                rb.velocity = new Vector2(0, -maxWallSlideVel);
            }      

    }


    //jumping code
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); ;
        rb.AddForce(Vector2.up * jumpForce);

        //if the player is in conact with a wall they get more height from this 
        if (WallSlidingR)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f); ;
            rb.AddForce(Vector2.right * wallJumpForce);
        }
        if (WallSlidingL)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f); ;
            rb.AddForce(Vector2.left * wallJumpForce);
        }
    
    }
}
   




