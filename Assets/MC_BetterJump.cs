using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_BetterJump : MonoBehaviour {

    public float fallMultiplier = 3.0f;
    public float lowJumpMultiplier = 1.5f;

    private Rigidbody2D rigidbody;

	void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		
        float xVelocity = rigidbody.velocity.x;

        if(rigidbody.velocity.y < 0){
            rigidbody.velocity = new Vector2(xVelocity, Physics2D.gravity.y * (fallMultiplier - 1));

        }else if(rigidbody.velocity.y > 0 && !Input.GetButton("Jump")){
            rigidbody.velocity = new Vector2(xVelocity, Physics2D.gravity.y * (lowJumpMultiplier - 1));
        }
	}
}
