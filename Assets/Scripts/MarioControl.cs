using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioControl : MonoBehaviour
{

    [SerializeField, Range(0, 10)]
    float speed;

    Animator anim;

    SpriteRenderer spr;


    Rigidbody2D rb;

    [SerializeField]
    Color rayColor = Color.magenta;

    [SerializeField]
    float raydistance = 1f;

    [SerializeField]
    LayerMask Ground;

    float salto;

    [SerializeField]
    float jumpstrenght;

    float a;

    [SerializeField]
    Text score;

    float count = 0;
    void Awake()
    {
        anim = GetComponent<Animator>();

        spr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        salto = 0;
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        a = rb.velocity.y;

        transform.Translate(Vector2.right * Axis.x * speed * Time.deltaTime);

       

        spr.flipX = Flip;

        if(Grounded)
        {

            anim.SetBool("Move", true);

            if (JumpButton)
            {


                salto = jumpstrenght;

            }

        }
        else
        {
            anim.SetBool("Move", false);

            salto = 0;

           

        }


        score.text = "Puntuacion " + count;
    }

    private void LateUpdate()
    {
        
        anim.SetFloat("moveX", Mathf.Abs(Axis.x));

    
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.up * salto, ForceMode2D.Impulse);

        anim.SetFloat("velocityY", Mathf.Clamp(a, -1, 1));
    }

    Vector2 Axis 
    {

        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }


    bool Flip
    {
        get => Axis.x < 0f ? false : Axis.x > 0f ? true : spr.flipX;
    }

    bool JumpButton
    {
        get => Input.GetButtonDown("Jump");
    }


    bool Grounded => Physics2D.Raycast(transform.position, Vector2.down, raydistance, Ground);

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;

        Gizmos.DrawRay(transform.position, Vector2.down * raydistance);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            count++;
            Destroy(collision.gameObject);
        }
    }
}

