using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
    private float timer = 120;
    private int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    void Update() {
        timer -= Time.deltaTime;

        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timer);

        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);

        if(timer <= 0){
            Debug.Log("Out of time");
            SceneManager.LoadScene("wip_1");
        }


    }

    void OnTriggerEnter2D(Collider2D trigger){

        if(trigger.gameObject.name == "FinishLine"){
            Debug.Log("Player reached the Finish Line: ");

            CountScore();
        }else if(trigger.gameObject.tag == "Broccoli"){
            playerScore += 10;
            Destroy(trigger.gameObject);
        }
        
    }

    void CountScore(){
        playerScore  = (int)(timer * 10) + playerScore;

        Debug.Log("Score: " + playerScore);

    }
}
