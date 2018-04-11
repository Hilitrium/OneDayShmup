using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {


    public float distance;
    Vector2 destination;
	// Use this for initialization
	void Start ()
    {
        destination = transform.position + (Vector3)(Random.insideUnitCircle * distance);
        StartCoroutine(movePos());
	}
	

    IEnumerator movePos()
    {
        float t = 0;
        Vector2 startpos = transform.position;
        float timeItTakes = 5;
        while(t < 1)
        {
            t += Time.deltaTime / timeItTakes;
            transform.position = Vector3.Lerp(startpos, destination, t);
            yield return null;
        }
    }


	// Update is called once per frame
	void Update () {
       
	}
}
