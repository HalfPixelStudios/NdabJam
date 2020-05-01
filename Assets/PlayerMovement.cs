using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector2.up * speed);
        }
 
        if(Input.GetKey(KeyCode.A)) {
            rb.AddForce(-Vector2.right * speed);
        }
 
        if(Input.GetKey(KeyCode.S)) {
            rb.AddForce(-Vector2.up * speed);
        }
 
        if(Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector2.right * speed);
        }



    }
}
