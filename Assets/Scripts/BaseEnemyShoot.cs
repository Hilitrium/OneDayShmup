using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyShoot : MonoBehaviour {

    public GameObject Bullet;
    public float speed;
    public int numOfBullets;
    public float bulletDelay;
    float timer;

    public float shootArc;
    public float perBulletDelay;

    // Use this for initialization
    void Start () {
        timer = bulletDelay;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            shootDelay();
            timer = bulletDelay;
        }
	}

    void shoot()
    {
        float totalArc = shootArc * numOfBullets;
        Vector2 shootDir = transform.up;
        shootDir = Quaternion.AngleAxis(totalArc/2, Vector3.forward) * shootDir;
        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject spawnedBullet = Instantiate(Bullet);
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
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
        shootDir = Quaternion.AngleAxis(totalArc/2, Vector3.forward) * shootDir;
        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject spawnedBullet = Instantiate(Bullet);
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
            yield return new WaitForSeconds(perBulletDelay);
        }
    }

}

