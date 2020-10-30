using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    // instantiate variables 
    
    [SerializeField] private GameObject gameOverCanvas; 
    [SerializeField] private float speed; // to act on the speed from the inspector
    [SerializeField] private float maxSpeed;// to act on the maximum speed from the inspector
    [SerializeField] private float JumpForce; // to act on the jump force

    private bool isOnGround = false; // to act on the fox's physics

    private PlayerMove PlayerMove; // to act on the fox's input actions
    private Vector2 direction; // to act the fox's direction
    private Rigidbody2D myRB; // modify fox's physics
    private Animator MyAnim; // act on the animations
    private SpriteRenderer MySprite; // act on the sprite

    


    private void OnEnable()
    {
        //Input system instantiate 
        var PlayerMove = new PlayerMove();

        // set input action 
        PlayerMove.Enable();

        // call the fonction when Move inputs are engaged
        PlayerMove.Main.Move.performed += OnMovePerformed; 

        // call of the fonction when Move inputs are not engaged anymore
        PlayerMove.Main.Move.canceled += OnMoveCanceled; 

        // call the fonction when Jump inputs are engaged
        PlayerMove.Main.Jump.performed += OnJumpPerformed; 
    }


    private void Start()
    {

        // call the player's rigidbody to act on it
        myRB = GetComponent<Rigidbody2D>(); 

        // call the animations to act on it
        MyAnim = GetComponent<Animator>();

        // call the renderer to act on it
        MySprite = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        //the player move only on the X axis
        var playerDirection = new Vector2(direction.x, 0);

        // As long as the player don't go as fast as maxSpeed, add a force
        if(myRB.velocity.sqrMagnitude < maxSpeed)
        {
            myRB.AddForce(playerDirection * speed);
        }
        
        // play the running anim as long as the player is doing it
        var isRunning = playerDirection.x != 0 ;
        MyAnim.SetBool("isRunning", isRunning);

        // flip the sprite (when the player goes to the left, he look to the left ...)
        if (direction.x <0)
        {
            MySprite.flipX = true;            
        }
        else if (direction.x > 0)
        {
            MySprite.flipX = false ;
        }
    
        // play the jumping anim when the fox's position on y is more than 0
        var isAscending = !isOnGround && myRB.velocity.y > 0;
        MyAnim.SetBool("isJumping", isAscending);

        //play the falling anim when the fox's position on y is less than 0
        var isDescending = !isOnGround && myRB.velocity.y < 0;
        MyAnim.SetBool("isFalling", isDescending);

        //play the idle anim when the fox is on the ground
        MyAnim.SetBool("isGrounded", isOnGround);        
    }


    // call the fonction to engage the movement of the player
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        // Get the position of the engaged inputs    
        direction = obj.ReadValue<Vector2>() ;
    }


    // call the fonction to engage the jump of the player
    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        // if the player is on the ground, add up force
        if(isOnGround)
        {
            myRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        } 
    }


    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        // no more force when inputs are not engaged
        direction = Vector2.zero;
    }


    // call the fonction to detect other objects
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if(other.gameObject.CompareTag("vide"))
        {
            GameOver() ;
            // Debug.Log("t'es mouru") ;
        }
    }

    // call the fonction to destroy the player and go to the menu scene
    public void GameOver()
    {
        Destroy(gameObject) ;
        SceneManager.LoadScene("MENU") ;
    }
    
}
