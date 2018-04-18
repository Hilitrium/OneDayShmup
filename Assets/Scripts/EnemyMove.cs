using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {


    public float distance;
    Vector2 destination;
    bool isMoving;
	// Use this for initialization
	void Start ()
    {
        destination = transform.position + (Vector3)(Random.insideUnitCircle * distance);
	}
	
    void Update()
    {
        if (destination.y >DrawEnemyBox.instance.BW && destination.y < DrawEnemyBox.instance.TW 
            && destination.x > DrawEnemyBox.instance.LW && destination.x < DrawEnemyBox.instance.RW
            && isMoving == false)
        {
            StartCoroutine(movePos());
            if(isMoving == false)
            {
                destination = transform.position + (Vector3)(Random.insideUnitCircle * distance);
            }
        }
        else
        {
            destination = transform.position + (Vector3)(Random.insideUnitCircle * distance);
        }
    }

    //void OnDrawGizmo()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(destination, 2);
    //}

    IEnumerator movePos()
    {
        //Initialization
        float t = 0;
        isMoving = true;
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


	
}
