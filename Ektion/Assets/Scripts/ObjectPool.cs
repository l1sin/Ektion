using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> Pool;
    public GameObject GameObjectToPool;
    public int PoolStartAmount;
    public void Start()
    {
        Pool = new();
        ExpandPool(PoolStartAmount);
    }
    public GameObject GetPooledObject(Vector3 p, Quaternion r)
    {
        GameObject temp;
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].activeInHierarchy)
            {
                temp = Pool[i];
                SetPooledObject(temp, p, r);
                return temp;
            }
        }
        temp = ExpandPool();
        SetPooledObject(temp, p, r);
        return temp;
    }
    public GameObject ExpandPool()
    {
        GameObject temp;
        temp = Instantiate(GameObjectToPool);
        temp.SetActive(false);
        temp.transform.SetParent(transform);
        Pool.Add(temp);
        return temp;
    }
    public void ExpandPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            ExpandPool();
        }
    }
    public GameObject SetPooledObject(GameObject g, Vector3 p, Quaternion r)
    {
        g.SetActive(true);
        g.transform.position = p;
        g.transform.rotation = r;
        return g;
    }
}
