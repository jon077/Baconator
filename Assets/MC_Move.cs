﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Move : MonoBehaviour {

    public int playerSpeed = 16;
    private bool facingRight = false;
    public int playerJumpPower = 2550;
    private float moveX;
    public bool isGrounded = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	
    
    }



    void PlayerMove () {
        //CONTROLS

        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            Jump();
        }
        //ANIMATIONS
        //PLAYERDIRECTION
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) {
            FlipPlayer();

        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed,
                                                                       gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up* playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer() {
        facingRight = !facingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        
    }


    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.collider.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }
}

