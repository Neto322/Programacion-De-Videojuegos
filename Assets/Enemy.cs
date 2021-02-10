using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float movespeed;

    [SerializeField]
    float timelimit;

    float timer = 0;

    float timerDelay = 0;

    [SerializeField]
    float delay = 0;
    
    [SerializeField]
    Vector2 dir = Vector2.right;


    SpriteRenderer spr;

    Animator anim;


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        

        if(timer < timelimit)
        {
            transform.Translate(dir * movespeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("idle");

            timerDelay += Time.deltaTime;

            if(timerDelay >= delay)
            {
                spr.flipX = flipsprite;
                dir.x = dir.x > 0 ? -1 : 1;
                timer = 0;
                timerDelay = 0;
                anim.SetTrigger("patrol");

            }
        }

    }

     bool flipsprite
    {
        get => dir.x > 0 ? true : false;
    }
}
