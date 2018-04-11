using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour {

    private BoxCollider2D backCollider;
    private float verticalLength;

	// Use this for initialization
	void Start () {
        backCollider = GetComponent<BoxCollider2D>();
        verticalLength = backCollider.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -verticalLength)
        {
            repositionBackground();
        }
	}

    private void repositionBackground()
    {
        Vector3 backOffset = new Vector3(0, verticalLength * 2f, 0);
        transform.position = (Vector3)transform.position + backOffset;
    }
}
