using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public int speed;
    public int damage = 1;

    //float lifetime = 8;

    private Rigidbody2D rb;

    PooledObject pool;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        pool = GetComponent<PooledObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement = new Vector2(0, 1);
        rb.AddForce(movement * speed);

        Destroy(gameObject, 1);
    }

    void OnTriggerEnter2D(Collider2D C)
    {
        if(C.gameObject.tag == "Enemy")
        {
            pool.returnToPool();
            //EnemyHealth enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            //enemyHealth.currentHealth -= damage;
            C.GetComponent<BaseEnemy>().takeDamage(damage);
        }
    }
}
