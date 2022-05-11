using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myrigidBody; // atribuindo o rigidbody a uma variável
    private bool isFacingRight = true; //checagem pra ver se o player tá virado pra direita
    public float moveSpeed = 10.0f; //velocidade do movimento
    public float runspeed; // velocidade da corrida 
    public float jumpForce = 16.0f; // força do pulo
    private float horizontal;

    
    
    

    // Dash utilities
    public float dashSpeed = 80.0f; // Dash speed/force
    public float startDashTimer = 0.15f; // Amount of time a player can maintain the dash
    public float startDashCooldown = 1.0f; // Amount of time waiting to be able to dash again
    float currentDashCooldown;
    float currentDashTimer;
    float dashDirection;
    bool canDash = true;
    bool isDashing = false;

    //Double jump e ground check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    public int extraJumps = 1;

    //Walljump
    private bool isOnWall;
    //public Transform wallCheckRight;
    //public Transform wallCheckLeft;
    public Transform wallCheck;
    public LayerMask whatisWall;
    public float wallCheckDistance;
    public HealthBehavior Healthbar;

   //private bool hasSword = true;
    


    //animator
    public Animator animator;
    [Header("Events")]
	[Space]
    public UnityEvent OnLandEvent;

    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>(); //inicializa o rigidbody
        
    }

    // Update is called once per frame
    void Update()
    {
        doubleJumpCheck();
        //CheckInput();
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        CheckMovementDirection();
        //dashCheck();
    }

    private void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatisGround);
        if(isGrounded){
            OnLandEvent.Invoke();
        }
        isOnWall = Physics2D.Raycast(wallCheck.position,transform.right,wallCheckDistance,whatisWall);
        ApplyMovement();

    }

    /*private void CheckInput(){

        movementInputDirection = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(movementInputDirection));
        if(Input.GetButtonDown("Jump") && extraJumps>0){
            Jump();
            animator.SetBool("IsJumping",true);
            extraJumps--;    
        }
    }
    */

   /* private void dashCheck(){
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift) && movementInputDirection != 0.0f && canDash){
            isDashing = true;
            currentDashTimer = startDashTimer;
            dashDirection = (int)movementInputDirection;
        }

        if (isDashing){
            Vector2 dashForceValue = new Vector2(dashSpeed * dashDirection, 0);
            myrigidBody.AddForce(dashForceValue);
            currentDashTimer -= Time.deltaTime;
            if (currentDashTimer <= 0){
                isDashing = false;
                canDash = false;
                currentDashCooldown = startDashCooldown;
            }
        }

        if (!canDash){
            currentDashCooldown -= Time.deltaTime;
            if (currentDashCooldown <= 0){
                canDash = true;
            }
        }
    }
    */

    private void ApplyMovement(){
        myrigidBody.velocity = new Vector2(horizontal * moveSpeed,myrigidBody.velocity.y);
        
    }

    public void Move(InputAction.CallbackContext context){
        horizontal = context.ReadValue<Vector2>().x;
    }


    //função que vira o player dependendo do input que ele botar 
    private void CheckMovementDirection(){
        if(isFacingRight && horizontal < 0){
            Flip();
        }
        else if(!isFacingRight && horizontal > 0){
            Flip();
        }
    }
    
    //  pulo 
   private void Jump(){
        myrigidBody.velocity = new Vector2(myrigidBody.velocity.x, jumpForce);

    }
    
    public void JumpAction(InputAction.CallbackContext context){
        if(context.performed && extraJumps>0){
            Jump();
            extraJumps--;
        }
    }
    
    private void doubleJumpCheck(){
        if(isGrounded || isOnWall){
            extraJumps = 1;
            
        }
            
    }


 
    // esse é o core do checkMovementDirection rotaciona a sprite e muda o status de onde ele ta olhando
    private void Flip(){
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f , 0.0f);
    }

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { 



    }

   

    
        
    
}
