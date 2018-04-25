using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int smallEnemies = 40;
    public int shotgunners = 15;

    int smallEnemiesKilled;
    int shotgunnersKilled;

    public float timeSmallSpawn;
    public float timeShotgunnerSpawn;

    GameObject spawnSmall;
    GameObject spawnShotguns;

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

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
