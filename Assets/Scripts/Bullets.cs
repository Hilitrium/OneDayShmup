using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public int speed;
    public int damage = 1;

    public float lifetime = 6;
    float timer;

    private Rigidbody2D rb;

    PooledObject pool;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        pool = GetComponent<PooledObject>();
        timer = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement = new Vector2(0, 1);
        rb.AddForce(movement * speed);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = lifetime;
            pool.returnToPool();
        }
    }

    void OnTriggerEnter2D(Collider2D C)
    {
        if(C.gameObject.tag == "Enemy")
        {
            timer = lifetime;
            pool.returnToPool();
            //EnemyHealth enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            //enemyHealth.currentHealth -= damage;
            BaseEnemy enemy = C.GetComponent<BaseEnemy>();
            if(enemy != null)
            {
                C.GetComponent<BaseEnemy>().takeDamage(damage);
            }
            
        }
    }
}
