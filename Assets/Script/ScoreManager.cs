using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text scoreText;
	public float playerScore;

	private SpawnObstacle spawnScript;
	private int highScore;
    // Start is called before the first frame update
    void Awake()
    {
    	GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawnScript = spawner.GetComponent<SpawnObstacle>();
        highScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) {
        	GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        	spawnScript.timeBetweenSpawn -= 0.01f *Time.deltaTime;
        	if(playerScore > highScore) {
        		highScore = (int)playerScore;
        	}
        	scoreText.text = "Score: " + ((int)playerScore).ToString() + "     Highest scrore: " + ((int)highScore).ToString(); 
        }
    }

    void OnDestroy() {
    	PlayerPrefs.SetInt("highscore", highScore);
    }
}
