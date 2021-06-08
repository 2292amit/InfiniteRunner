using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	AudioSource audioData;
	GameObject player;
	ScoreManager scorer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    	audioData = GetComponent<AudioSource>();
    	GameObject manager = GameObject.FindGameObjectWithTag("Scorer");
        scorer = manager.GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
    	if(collision.tag == "Border") {
    		scorer.playerScore += 1;
    		Destroy(this.gameObject);
    	}
    	else if (collision.tag == "Player") {
    		audioData.Play(0);
    		Destroy(player.gameObject);
    	}
    }
}
