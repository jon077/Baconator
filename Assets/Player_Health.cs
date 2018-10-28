using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -7) {
            Die();
        }
	}

    void Die () {
        Debug.Log("Player has died");
        SceneManager.LoadScene("wip_1");
    }

}

