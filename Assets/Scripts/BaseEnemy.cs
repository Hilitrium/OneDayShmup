﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //Health
    protected int currentHealth;
    public int maxHealth = 25;

    //Movement
    public float distance;
    Vector2 destination;
    protected bool isMoving;

    //Shooting
    ObjectPool pool;
    public GameObject Bullet;
    public float speed;
    public int numOfBullets;
    public float bulletDelay;
    protected float timer;

    public float shootArc;
    public float perBulletDelay;

    protected virtual void Start ()
    {
        ////Set a starting destination
        //destination = new Vector2(Random.Range(DrawEnemyBox.instance.LW, DrawEnemyBox.instance.RW),
        //    Random.Range(DrawEnemyBox.instance.TW, DrawEnemyBox.instance.BW));

        ////Set up timer
        //timer = bulletDelay;

        //pool = GetComponent<ObjectPool>();
        initBaseEnemy();
    }

    protected void initBaseEnemy()
    {
        //Set a starting destination
        destination = new Vector2(Random.Range(DrawEnemyBox.instance.LW, DrawEnemyBox.instance.RW),
            Random.Range(DrawEnemyBox.instance.TW, DrawEnemyBox.instance.BW));

        //Set up timer
        timer = bulletDelay;

        pool = GetComponent<ObjectPool>();
    }
	
    void Update()
    {
        //Ensure enemy is moving
        if (isMoving == false)
        {
            newDestination();
            isMoving = true;
            StartCoroutine(movePos());
        }

        //firing weapons
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            shootDelay();
            timer = bulletDelay;
        }
    }

    public IEnumerator movePos()
    {
        //Initialization
        float t = 0;
        Vector2 startpos = transform.position;
        float timeItTakes = 5;
        //Update
        while (t < 1)
        {
            t += Time.deltaTime / timeItTakes;
            transform.position = Vector3.Lerp(startpos, destination, t);
            yield return null;
        }
        //Clean up
        isMoving = false;
    }

    protected void newDestination()
    {
        //reset Destination
        destination = new Vector2(Random.Range(DrawEnemyBox.instance.LW, DrawEnemyBox.instance.RW),
            Random.Range(DrawEnemyBox.instance.TW, DrawEnemyBox.instance.BW));
    }

    public void takeDamage(int damageTaken)
    {
        //taking damage and death reset
        Debug.Log("damageTaken");
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            GameManager.instance.enemiesKilled++;
            resetEnemy();
            GameManager.instance.updateGameManager();
        }
    }

    protected void resetEnemy()
    {
        //reseting the enemy when sending back to pool
        PooledObject pool = GetComponent<PooledObject>();
        pool.returnToPool();
        currentHealth = maxHealth;
        destination = new Vector2(Random.Range(DrawEnemyBox.instance.LW, DrawEnemyBox.instance.RW),
           Random.Range(DrawEnemyBox.instance.TW, DrawEnemyBox.instance.BW));
        isMoving = false;
        //enemiesKilled++;
    }

    //Basic shoot function
    protected void shoot()
    {
        float totalArc = shootArc * numOfBullets;
        Vector2 shootDir = transform.up;
        shootDir = Quaternion.AngleAxis(totalArc / 2, Vector3.forward) * shootDir;
        for (int i = 0; i < numOfBullets; i++)
        {
            //GameObject spawnedBullet = Instantiate(Bullet);
            GameObject bullet = pool.getObject();
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            bullet.transform.up = -shootDir.normalized;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
        }
    }

    //Shooting with a delay between bullets
    protected void shootDelay()
    {
        StartCoroutine(shootWithDelay());
    }

    IEnumerator shootWithDelay()
    {
        float totalArc = shootArc * numOfBullets;
        Vector2 shootDir = transform.up;
        shootDir = Quaternion.AngleAxis(totalArc / 2, Vector3.forward) * shootDir;
        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject spawnedBullet = pool.getObject();
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            spawnedBullet.transform.up = -shootDir.normalized;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
            yield return new WaitForSeconds(perBulletDelay);
        }
    }
}
