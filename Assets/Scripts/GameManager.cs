using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    //public int smallEnemies = 40;
    //public int shotgunners = 15;

    public int enemiesKilled;

    protected float timeSmallSpawn;
    protected float timeShotgunnerSpawn;

    private float timeSmallStart;
    private float timeShotgunnerStart;

    public EnemySpawn spawnSmall;
    public EnemySpawn spawnShotguns;

	// Use this for initialization
	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        timeSmallStart = timeSmallSpawn;
        timeShotgunnerStart = timeShotgunnerSpawn;

        DontDestroyOnLoad(gameObject);
	}
	
    float calculateSmallSpawn()
    {
        float newTimeSmall = timeSmallSpawn - 0.1f;
        return newTimeSmall;
    }

    float calculateShotgunSpawn()
    {
        float newTimeShotgun = timeShotgunnerSpawn - 0.055f;
        return newTimeShotgun;
    }
    public void updateGameManager()
    {
        enemiesKilled++;
        if (timeSmallSpawn > 1.5f)
        {
            //small Enemy adjustment
            timeSmallSpawn = calculateSmallSpawn();
            spawnSmall.getInfoFromGameManager(timeSmallSpawn);
        }

        if (timeShotgunnerSpawn > 2.0f)
        {
            //shotgunner Enemy spawn
            timeShotgunnerSpawn = calculateShotgunSpawn();
            spawnShotguns.getInfoFromGameManager(timeShotgunnerSpawn);
        }
        //Evaulate boss requirementss
        if(enemiesKilled >= 50)
        {

        }
        
    }
	
}
