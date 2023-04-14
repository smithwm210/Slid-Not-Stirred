using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool gameStarted;
    private float horizontal;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardsSpeed;
    [SerializeField] private float constantSpeed;
    private float curSpeed;



    [SerializeField] private float jumpingPower;

    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    private bool canDash = true;
    private bool isDashing;


    private bool isJumping;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //private int totalHealth = 3;

    private void Start()
    {
        curSpeed = constantSpeed;
        GetComponent<PlayerController2>().enabled = false;
    }

    
    private void Update()
    {
        if(isDashing){
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown("c") && canDash){
           StartCoroutine(Dash());
        }
        
        if(Input.GetKeyDown("d")){
            curSpeed = forwardSpeed;
        }
        if(Input.GetKeyDown("a")){
            curSpeed = backwardsSpeed;
        }
        
        if((Input.GetKeyUp("d") || Input.GetKeyUp("a")) &&
        (!Input.GetKeyDown("d") && !Input.GetKeyDown("a")) ){
            curSpeed = constantSpeed;
        }
        
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            FindObjectOfType<AudioManager>().Play("Jump Sound");
            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate()
    {
         if(isDashing){
            return;
        }
        rb.velocity = new Vector2(curSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(.65f);
        isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Debug.Log("Collided");
            StartCoroutine(LoseHealth());
        }
    }

    //dashing mechanic
    private IEnumerator Dash(){

        canDash = false;
        isDashing = true;
        float originalGravScale = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = (new Vector2(transform.localScale.x *dashPower,0f));
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravScale;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    
    private IEnumerator LoseHealth()
    {
        //brief invincibility (layer 6 is player, 7 is obstacle)
        Physics2D.IgnoreLayerCollision(6, 7, true);

        //play getting hit sound
        //FindObjectOfType<AudioManager>().Play("Hit Obstacle");

        //spill drink animation

        //decrement health bar
        // totalHealth--;
        // switch(totalHealth)
        // {
        //     case 2:
        //         //change health bar sprite to 2/3
        //         break;
        //     case 1:
        //         //change health bar sprite to 1/3
        //         //maybe with something else for polish, like slightly red?
        //         break;
        //     case 0:
        //         //change to empty glass 0/3
        //         //what happens when it's empty?
        //         break;
        //     default:
        //         break;
        // }
         

        //apply leftward force? (decrease their horiz speed)

        yield return new WaitForSeconds(0.75f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        

    }
}
