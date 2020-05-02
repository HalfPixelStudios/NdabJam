using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerSlot playerSlot;

    private Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    public float offsetX;
    public float offsetY;
    

    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerSlot = GetComponent<PlayerSlot>();

    }

    void Update() {

        var inp = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        transform.position += new Vector3(inp.x,inp.y,0f) * Time.deltaTime * speed;

        //flip player based on direction of movement
        if (inp.x != 0) {
            sr.flipX = inp.x < 0;
        }

        if (inp != Vector2.zero)
        {
            //playerSlot.transform.position = new Vector3(offsetX*(inp.x<0?-1:1),offsetY*(inp.y<0?-1:1),0);
            
        }
        


    }
}
