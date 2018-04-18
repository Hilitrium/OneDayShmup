using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmarterEnemy : DummyEnemy {

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth * 2;
	}

    protected override void enemyMove()
    {
        //base.enemyMove();
        //Move up
        //Run shoot left
    }

    // Update is called once per frame
    void Update () {
		
	}
}
