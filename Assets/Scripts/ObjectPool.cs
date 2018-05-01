using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public GameObject pooledObj;
    public Stack<GameObject> pool;

    public int poolAmount;

	// Use this for initialization
	void Start () {
        pool = new Stack<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject spawnedObj = Instantiate(pooledObj);
            spawnedObj.transform.SetParent(transform);
            spawnedObj.GetComponent<PooledObject>().myPool = this;
            spawnedObj.SetActive(false);
            pool.Push(spawnedObj);
        }
        Debug.Assert(pool.Count == poolAmount);
	}
	
	public GameObject getObject()
    {
        if (pool.Count > 0)
        {
            GameObject poppedOb = pool.Pop();
            poppedOb.transform.SetParent(null);
            poppedOb.SetActive(true);
            return poppedOb;
        }
        else
        {
            Debug.LogError("wtf");
            poolAmount *= 2;
            for(int i = 0; i < poolAmount; i++)
            {
                GameObject spawnedObj = Instantiate(pooledObj);
                spawnedObj.transform.SetParent(transform);

                spawnedObj.SetActive(false);
                pool.Push(spawnedObj);
            }
            GameObject poppedOb = pool.Pop();
            poppedOb.transform.SetParent(null);
            poppedOb.SetActive(true);
            return poppedOb;
        }
    }
}
