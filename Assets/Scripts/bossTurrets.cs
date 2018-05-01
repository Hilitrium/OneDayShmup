using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTurrets : MonoBehaviour {

    //use script only on extra boss turrets

    public GameObject bullet;
    GameObject player;
    ObjectPool pool;

    public float rotationSpeed;

    public float speed;
    public int numOfBullets;
    public float bulletDelay;
    float timer;

    public float shootArc;
    public float perBulletDelay;

    // Use this for initialization
    void Start () {
	    player = GameObject.FindGameObjectWithTag("Player");
        timer = bulletDelay;
        pool = GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
        //Targeting
        transform.up = Vector3.Slerp(transform.up, player.transform.position - transform.position,
            Time.deltaTime / rotationSpeed);

        //shooting
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            shootDelay();
            timer = bulletDelay;
        }
    }

    void shootDelay()
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
            Debug.Log("go " + i);
            GameObject spawnedBullet = pool.getObject();
            spawnedBullet.GetComponent<EnemyBullets>().OnReset();
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            spawnedBullet.transform.up = -shootDir.normalized;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
            yield return new WaitForSeconds(perBulletDelay);
            
        }
    }
}
