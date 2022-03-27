using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D myrigidBody; // atribuindo o rigidbody a uma variável
    private bool isFacingRight = true; //checagem pra ver se o player tá virado pra direita
    private float movementInputDirection; // checagem pra ver qual botão ele tá apertando (pra mover)
    public float moveSpeed = 10.0f; //velocidade do movimento
    public float runspeed; // velocidade da corrida 
    public float jumpForce = 16.0f; // força do pulo
    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>(); //inicializa o rigidbody
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckInput();
        CheckMovementDirection();
    }

    private void FixedUpdate() {

        ApplyMovement();
    }

    private void CheckInput(){

        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        
    }

    private void ApplyMovement(){
        myrigidBody.velocity = new Vector2(moveSpeed * movementInputDirection,myrigidBody.velocity.y);
    }

    //função que vira o player dependendo do input que ele botar 
    private void CheckMovementDirection(){
        if(isFacingRight && movementInputDirection < 0){
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0){
            Flip();
        }
    }

    //  pulo 
    private void Jump(){
        myrigidBody.velocity = new Vector2(myrigidBody.velocity.x, jumpForce);

    }

    // esse é o core do checkMovementDirection rotaciona a sprite e muda o status de onde ele ta olhando
    private void Flip(){
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f , 0.0f);
    }
}
