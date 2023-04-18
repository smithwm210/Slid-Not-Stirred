using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private float incrimentingSpeed;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardsSpeed;
    [SerializeField] private float constantSpeed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public TextMeshProUGUI subtitles;

    //private SpriteRenderer rend;

    private float curConstant;
    private float curForward;
    private float curBackwards;

    public HealthBar healthBar;
    private bool gameStarted;
    private float horizontal;
    private float curSpeed;
    private bool canDash = true;
    private bool isDashing;
    private bool isJumping;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public int maxHealth = 10;
    private int curHealth;
    public static PlayerController2 instance;

    //private bool isFlashing;
    private void Start()
    {   
        healthBar.SetMaxHealth(maxHealth);
        curHealth = maxHealth;
    }

    private void Update()
    {
        if(isDashing){
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Dash") && canDash && curHealth >= 1){
           FindObjectOfType<AudioManager>().Play("Dash Sound"); 
           subtitles.text = "cominhos e uvas";
           StartCoroutine(Dash());
        }
        
        if(Input.GetKeyDown("d") || horizontal > 0){
            curSpeed = forwardSpeed;
        }
        
        if(Input.GetKeyDown("a") || horizontal < 0){
            curSpeed = backwardsSpeed;
        }
        
        if((Input.GetKeyUp("d") || Input.GetKeyUp("a") || horizontal == 0) &&
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
            subtitles.text = "Sliding window";
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
        curHealth--;
        healthBar.SetHealth(curHealth);
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
        FindObjectOfType<AudioManager>().Play("Hit Sound"); 
        subtitles.text = "The house collapsed and water came out.";

        //flash the player sprite

        StartCoroutine(FlashRoutine());
        
        //play the spill drink animation

        //decrement health bar
         curHealth -= 2;
         healthBar.SetHealth(curHealth);

        yield return new WaitForSeconds(1.0f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    private IEnumerator FlashRoutine()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.20f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.20f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.10f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.10f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.05f);
    }


    public void IncreaseSpeed(){
        for(int i = 1; i < FindObjectOfType<GameManager>().round; i++){
            constantSpeed += incrimentingSpeed;
            forwardSpeed += incrimentingSpeed;
            backwardsSpeed += incrimentingSpeed;
        }
    }

    public float GetHealth(){
        float tmpHealth = curHealth;
        return tmpHealth;
    }
}
