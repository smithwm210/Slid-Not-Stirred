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

    private bool isJumping;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Start() {
        curSpeed = constantSpeed;
        GetComponent<PlayerController2>().enabled = false;
    }

    
    private void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        
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

    private IEnumerator LoseHealth()
    {
        //brief invincibility (layer 6 is player, 7 is obstacle)
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        
        //decrease horizontal velocity?
        //spill drink animation
        //flash sprite on and off for a second
    }
}
