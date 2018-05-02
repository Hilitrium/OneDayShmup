using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {

    public int speed;
    public int damage = 1;
    public float lifetime = 5;
    float lifeTimer;
    PooledObject pool;

    //float lifetime = 8;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pool = GetComponent<PooledObject>();
        OnReset();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 movement = new Vector2(0, 1);
        //rb.AddForce(movement * speed);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            OnReset();
            pool.returnToPool();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            PlayerController PlayerController = c.gameObject.GetComponent<PlayerController>();
            PlayerController.takeDamage(damage);
            OnReset();
            pool.returnToPool();
        }
    }

    public void OnReset()
    {
        lifeTimer = lifetime;
    }
}
