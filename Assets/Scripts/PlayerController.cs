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

    // Use this for initialization
    void Start()
    {
        HeavyBulletsRemaining = heavyBulletsMax;
    }

    // Update is called once per frame
    void Update()
    {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (Input.GetKey(KeyCode.Mouse0)) {
            GameObject clone;
            clone = Instantiate(smallBullets) /*as Rigidbody2D*/;
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            clone.transform.position = transform.position + new Vector3(0, 1);
            cloneRb.velocity = transform.TransformDirection(Vector2.up * 10);
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
