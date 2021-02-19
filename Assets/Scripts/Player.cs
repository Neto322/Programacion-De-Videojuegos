using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController2D
{

   [SerializeField, Range(0.1f, 10f)]
    float moveSpeed = 1f;

    [SerializeField, Range(0.1f, 15f)]
    float jumpForce;

    new void Awake()
    {
        base.Awake();
    }

    void Start()
    {


        playerControls.Gameplay.Jump.performed += ctx => Jump();


    }

    void Update()
    {
        Debug.Log(IsGrounding);
    }

    void Jump()
    {
        if(IsGrounding)
        {

            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }


    void FixedUpdate() 
    {
        
        AddForceMovement(moveSpeed);
        
      

    }

    void LateUpdate() 
    {
        if(IsGrounding)
        {
            anim.SetBool("Move",true);

        }
        if(!IsGrounding)
        {
            anim.SetBool("Move",false);

        }
        spr.flipX = flipSprite; 
     
        anim.SetBool("Move",true);
        
        anim.SetFloat("moveX",Mathf.Abs(playerControls.Gameplay.Movement.ReadValue<Vector2>().x));   

            anim.SetFloat("velocityY",rb2D.velocity.y);
        

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();

            GameManager.instance.GetScore.AddPoints(coin.Points);


            Destroy(other.gameObject);
        }    
    }

    
}
