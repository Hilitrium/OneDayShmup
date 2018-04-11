using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public int speed;
    public int damage = 1;

    //float lifetime = 8;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement = new Vector2(0, 1);
        rb.AddForce(movement * speed);

        Destroy(gameObject, 1);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            EnemyHealth enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.currentHealth -= damage;
        }
    }
}
