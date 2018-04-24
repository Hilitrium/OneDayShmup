using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledEnemy : MonoBehaviour {

    public EnemyPool myPool;

    public void returnToPool()
    {
        gameObject.SetActive(false);
        transform.parent = myPool.transform;
        myPool.pool.Push(gameObject);
    }
}
