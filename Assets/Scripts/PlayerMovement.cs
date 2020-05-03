using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    

    public float speed;
    public float footstepDistance = 1f;
    float distSinceStep = 0;
    Vector3 prevPosition;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        prevPosition = transform.position;
    }

    void Update() {

        if (PauseMenu.isPaused) { return; }

        var inp = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //transform.position += new Vector3(inp.x,inp.y,0f) * Time.deltaTime * speed;
        rb.velocity = new Vector3(inp.x, inp.y, 0f) * speed;

        //flip player based on direction of movement
        int rot;
        if (inp.x != 0) {
            sr.flipX = inp.x < 0;

            rot = sr.flipX ? 5 : -5;
           
        } else { rot = 0; }

        transform.rotation=Quaternion.Euler(0,0,Mathf.LerpAngle(transform.eulerAngles.z,rot,0.7f));

        //footstep sound stuff
        distSinceStep += Vector3.Distance(transform.position,prevPosition);
        if (distSinceStep > footstepDistance) {
            distSinceStep = 0;
            SoundPlayer.quickRandomSound("Sounds/footsteps",1f);
        }

        prevPosition = transform.position;
    }
}
