using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioControl : MonoBehaviour
{

    [SerializeField, Range(0, 10)]
    float speed;

    Animator anim;

    SpriteRenderer spr;

    void Awake()
    {
        anim = GetComponent<Animator>();

        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * speed * Time.deltaTime);

        spr.flipX = Flip;
    }

    private void LateUpdate()
    {
        anim.SetFloat("moveX", Mathf.Abs(Axis.x));
    }


    Vector2 Axis 
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }


    bool Flip
    {
        get => Axis.x < 0f ? false : Axis.x > 0f ? true : spr.flipX;
    }
}

