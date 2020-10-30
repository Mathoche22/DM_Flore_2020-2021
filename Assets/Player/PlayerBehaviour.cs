using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    // variables 

    private PlayerMove PlayerMove;
    private Vector2 direction;

    private Rigidbody2D myRB;
    private Animator MyAnim;
    private SpriteRenderer MySprite;

    [SerializeField] private float speed; 
    [SerializeField] private float maxSpeed;
    [SerializeField] private float JumpForce; 
    

    [SerializeField] private GameObject gameOverCanvas; 


    private void OnEnable()
    {
        //Input system instantiate 
        PlayerMove = new PlayerMove();

        PlayerMove.Enable();
        // call the fonction when Move inputs are engaged
        PlayerMove.Main.Move.performed += OnMovePerformed; 

        // call of the fonction when Move inputs are not engaged anymore
        PlayerMove.Main.Move.canceled += OnMoveCanceled; 

        // call the fonction when Jump inputs are engaged
        //PlayerMove.Main.Jump.performed += OnJumpPerformed; 

        // call the player's rigidbody to act on it
        myRB = GetComponent<Rigidbody2D>(); 

        // call the animations to act on it
        MyAnim = GetComponent<Animator>();

        // call the renderer to act on it
        MySprite = GetComponent<SpriteRenderer>();

    }


    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        // no more force when inputs are not engaged
        direction = Vector2.zero;
    }


    // call the fonction to engage the movement of the player
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        // Get the position of the engaged inputs        
        direction = obj.ReadValue<Vector2>() ;
        Debug.Log(direction) ;
    }

    private void Start()
    {
        MyAnim.SetBool("isRunning", false);
        MyAnim.SetBool("isJumping", false);
        MyAnim.SetBool("isFalling", false);

    }

    // call the fonction to engage the jump of the player
    /*private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        // if the player is on the ground, add up force
        if(IsOnGround)
        {
            myRB.AddForce(Vector2.up *JumpForce, ForceMode2D.Impulse) ;
            // stop to ad force once input are not engaged
            
        } 
    }

    void FixedUpdate()
    {
        //the player move only on the X axis
        direction.y = 0;

        // As logn as the player don't go as fast as maxSpeed, add a force
        if(myRB.velocity.sqrMagnitude < maxSpeed)
        {
            myRB.AddForce(direction * speed);
        }
        
        // call the running animation of the player
        var isRunning = direction.x != 0 ;
        // play the running anim as long as the player is doing it
        MyAnim.SetBool("isRunning", isRunning);

        // direction.x = 0;
        if(myRB.velocity.sqrMagnitude < JumpForce)
        {
            myRB.AddForce(direction * JumpForce);
        }
        
        // call the jumping animation of the player
        var isJumping = direction.y != 0;
        // play the jumping anim as long as the player is doing it
        MyAnim.SetBool("isJumping", isJumping);
        
        // flip the sprite (when the player goes to the left, he look to the left ...)
        if (direction.x <0)
        {
            MySprite.flipX = true;            
        }
        else if (direction.x > 0)
        {
            MySprite.flipX = false ;
        }
        
    }
    
    
    // call the fonction to detect other objects
    private void OnCollisionEnter2D(Collision2D other)
    {
        // if the player enter in collision with an object, then he can jump
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("vide"))
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
    */

  
    
}
