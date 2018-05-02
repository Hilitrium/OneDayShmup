using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Bullets to use
    public GameObject smallBullets;
    public GameObject HeavyBullets;

    //Total Heavy ammo
    public int heavyBulletsMax = 10;
    int HeavyBulletsRemaining;

    //Mouse position and movement
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    //Delay Between Shots
    float timerstart = 0.05f;
    float timer;

    //Bullet pool
    ObjectPool pool;

    //Health
    public int maxHealth = 20;
    public int currentHealth;
    float deathDelay = 2;

    void Start()
    {
        currentHealth = maxHealth;
        HeavyBulletsRemaining = heavyBulletsMax;
        timer = timerstart;
        pool = GetComponent<ObjectPool>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (Input.GetKey(KeyCode.Mouse0) && timer < 0) {
            GameObject bullet = pool.getObject(); ;
            //Rigidbody2D cloneRb = bullet.GetComponent<Rigidbody2D>();
            //bullet.transform.position = transform.position + new Vector3(0, 1);
            //cloneRb.velocity = transform.TransformDirection(Vector2.up * 10);
            bullet.transform.position = transform.position + new Vector3(0, 1);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * 10);
            timer = timerstart;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && HeavyBulletsRemaining > 0)
        {
            GameObject clone;
            clone = Instantiate(HeavyBullets) /*as Rigidbody2D*/;
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            clone.transform.position = transform.position + new Vector3(0, 1);
            cloneRb.velocity = transform.TransformDirection(Vector2.up * 10);
            HeavyBulletsRemaining--;
        }
    }

    public void takeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            deathDelay -= Time.deltaTime;
            if(timer <= 0)
            {
                string sceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }
}
