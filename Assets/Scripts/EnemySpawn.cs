using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    EnemyPool pool;

    public float timeBetweenSpawn = 7;
    private float timer;

	// Use this for initialization
	void Start () {
        pool = GetComponent<EnemyPool>();
        timer = timeBetweenSpawn;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            spawn();
            timer = timeBetweenSpawn;
            
            Debug.Log("Enemy Spawned");
        }

		//if (Input.GetKeyDown(KeyCode.Space))
  //      {
  //          spawn();
  //          Debug.Log("Enemy Spawned");
  //      }
	}

    void spawn()
    {
        GameObject spawnedEnemy = pool.getObject();
        spawnedEnemy.transform.position = transform.position;
    }

    
}
