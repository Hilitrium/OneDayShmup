using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {

    public ObjectPool myPool;

    public void returnToPool()
    {
        gameObject.SetActive(false);
        transform.parent = myPool.transform;
        myPool.pool.Push(gameObject);
        //Debug.Log("Returned To Pool");
    }
}
