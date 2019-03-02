using System.Collections;
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

        PlayerRaycast();
	
    
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

    void PlayerRaycast(){
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position,Vector2.down);

        if(hit2D.distance < 1.7f && hit2D.collider.tag == "Enemy"){            
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10000);
        }

        if(hit2D.distance < 1.7f && hit2D.collider.tag != "Enemy"){            
            isGrounded = true;
        }
    }
}

