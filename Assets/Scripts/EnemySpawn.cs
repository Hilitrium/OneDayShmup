using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    EnemyPool pool;
    

	// Use this for initialization
	void Start () {
        pool = GetComponent<EnemyPool>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            spawn();
            Debug.Log("Enemy Spawned");
        }
	}

    void spawn()
    {
        GameObject spawnedEnemy = pool.getObject();
        spawnedEnemy.transform.position = transform.position;
    }

    
}
