using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool SharedInstance;
    public int amountToPool;

    public List<GameObject> pooledPistols;
    public GameObject pistolToPool;

    public List<GameObject> pooledUzis;
    public GameObject uziToPool;

    public List<GameObject> pooledRifles;
    public GameObject rifleToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledPistols = new List<GameObject>();
        pooledUzis = new List<GameObject>();
        pooledRifles = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < amountToPool; i++)
        {
            bullet = Instantiate(pistolToPool);
            bullet.SetActive(false);
            pooledPistols.Add(bullet);

            bullet = Instantiate(uziToPool);
            bullet.SetActive(false);
            pooledUzis.Add(bullet);

            bullet = Instantiate(rifleToPool);
            bullet.SetActive(false);
            pooledRifles.Add(bullet);
        }
    }

    public GameObject GetPistol()
    {
        return GetPooledObject(pooledPistols);
    }

    public GameObject GetUzi()
    {
        return GetPooledObject(pooledUzis);
    }

    public GameObject GetRifle()
    {
        return GetPooledObject(pooledRifles);
    }

    private GameObject GetPooledObject(List<GameObject> pooledObjects)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
