using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public GameObject bullet;
    public float speed;
    public int numOfBulletsShot;
    public float bulletDelay;
    float timer;

    public float shootArc;
    public float perBulletDelay;
	// Use this for initialization
	void Start () {
		
	}


    IEnumerator shootWithDelay()
    {
        Vector2 shootDir = transform.up;
        shootDir = Quaternion.AngleAxis(shootArc, Vector3.forward) * shootDir;
        for (int i = 0; i < numOfBulletsShot; i++)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
            yield return new WaitForSeconds(perBulletDelay);
        }
    }


    void shoot()
    {
        Vector2 shootDir = transform.up;
        shootDir = Quaternion.AngleAxis(shootArc, Vector3.forward) * shootDir;
        for(int i = 0; i < numOfBulletsShot; i++)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
            shootDir = Quaternion.AngleAxis(-shootArc, Vector3.forward) * shootDir;
        }
    }


    void playShootDelay()
    {
        StartCoroutine(shootWithDelay());
    }
    public bool editorShoot;
	// Update is called once per frame
	void Update ()
    {
		if(editorShoot)
        {
            //shoot();
            playShootDelay();
            editorShoot = false;
        }
	}
}
