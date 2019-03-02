using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab1_Move : MonoBehaviour {

    
    public int xDirection;
    public int velocity;

    // Update is called once per frame
    void Update() {

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, new Vector2(xDirection, 0));

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection, 0) *
            velocity;

        if(hit2D.distance < 1.95f){
            FlipCrab();

            if(hit2D.collider.tag == "Player"){
                Destroy(hit2D.collider.gameObject);
            }
        }
    }


    
    void FlipCrab() {

        xDirection = xDirection * -1;
        
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
