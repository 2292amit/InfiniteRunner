using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
	public GameObject obstacle;
    public GameObject bird;
	public float maxX;
	public float maxY;
	public float minX;
	public float minY;
	public float timeBetweenSpawn;
	private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime) {
            int random = Random.Range(0, 2);
            if(random == 0) {
                SpawnKid();
            }
            else {
                SpawnBird();
            }
        	spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnKid() {
    	float randomX = Random.Range(minX, maxX);
    	Instantiate(obstacle, transform.position + new Vector3(randomX, 0, 0), transform.rotation);
    }

    void SpawnBird() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(bird, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
