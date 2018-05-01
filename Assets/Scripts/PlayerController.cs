using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject smallBullets;
    public GameObject HeavyBullets;

    public int heavyBulletsMax = 10;
    int HeavyBulletsRemaining;

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    float timerstart = 0.05f;
    float timer;

    ObjectPool pool;

    // Use this for initialization
    void Start()
    {
        HeavyBulletsRemaining = heavyBulletsMax;
        timer = timerstart;
        pool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
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
}
