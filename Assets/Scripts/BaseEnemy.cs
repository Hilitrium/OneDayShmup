using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    int currentHealth;
    public int maxHealth = 30;

    public float distance;
    Vector2 destination;
    bool isMoving;
	
	void Start ()
    {
        destination = transform.position + (Vector3)(Random.insideUnitCircle * distance);
        currentHealth = maxHealth;
	}
	
    void Update()
    {
        if (isMoving == false)
        {
            newDestination();
            isMoving = true;
            StartCoroutine(movePos());
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator movePos()
    {
        //Initialization
        float t = 0;
        Vector2 startpos = transform.position;
        float timeItTakes = 5;
        //Update
        while (t < 1)
        {
            t += Time.deltaTime / timeItTakes;
            transform.position = Vector3.Lerp(startpos, destination, t);
            yield return null;
        }
        //Clean up
        isMoving = false;
    }

    void newDestination()
    {
        destination = new Vector2(Random.Range(DrawEnemyBox.instance.LW, DrawEnemyBox.instance.RW),
            Random.Range(DrawEnemyBox.instance.TW, DrawEnemyBox.instance.BW));
    }
	
    public void takeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

}
