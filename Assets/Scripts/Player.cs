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

    }

    void Jump()
    {
        if(IsGrounding)
        {
            anim.SetTrigger("jump");

            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }


    void FixedUpdate() 
    {
        
        AddForceMovement(moveSpeed);

      

    }

    void LateUpdate() 
    {
        spr.flipX = flipSprite; 

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
