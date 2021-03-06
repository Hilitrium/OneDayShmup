﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    ObjectPool pool;

    public float timeBetweenSpawn = 7;
    private float timer;

	// Use this for initialization
	void Start () {
        pool = GetComponent<ObjectPool>();
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

    public void getInfoFromGameManager(float newTimer)
    {
        timeBetweenSpawn = newTimer;
    }

    void spawn()
    {
        GameObject spawnedEnemy = pool.getObject();
        spawnedEnemy.transform.position = transform.position;
    }

    
}
