using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunnerEnemy : BaseEnemy {

    GameObject player;

   // float timer;

   // bool isMoving;
    public float rotationSpeed;
    // Use this for initialization
    void Start () {
        initBaseEnemy();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
    IEnumerator lookAtPlayer()
    {
        Vector3 startRot = transform.forward;
        Vector3 desiredRot = player.transform.position - transform.position;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime / rotationSpeed;
            transform.forward = Vector3.Slerp(startRot, desiredRot, t);
            if(t >= 1)
            {
                startRot = transform.forward;
                desiredRot = player.transform.position - transform.position;
                t = 0;
            }
            yield return null;
        }
    }

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

	// Update is called once per frame
	void Update () {
       // transform.up = player.transform.position - transform.position;

        transform.up = Vector3.Slerp(transform.up, player.transform.position - transform.position, 
            Time.deltaTime / rotationSpeed);

        if (isMoving == false)
        {
            newDestination();
            isMoving = true;
            StartCoroutine(movePos());
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            shootDelay();
            timer = bulletDelay;
        }
    }
}
