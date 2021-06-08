using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private GameObject player;
	AudioSource audioData;
	ScoreManager scorer;
    // Start is called before the first frame update
    void Awake()
    {
    	player = GameObject.FindGameObjectWithTag("Player");
    	audioData = GetComponent<AudioSource>();
    	GameObject manager = GameObject.FindGameObjectWithTag("Scorer");
        scorer = manager.GetComponent<ScoreManager>();
        int random = Random.Range(0, 6);
        this.gameObject.transform.GetChild(random).gameObject.SetActive(true);
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
