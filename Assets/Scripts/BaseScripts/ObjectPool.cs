using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Base
{
    [Serializable]
    public class Pool
    {
        public ObjectTag objectTag;
        public int size;
        public GameObject Prefab;
    }
    public Dictionary<ObjectTag, Queue<GameObject>> keyValue;
    public List<Pool> Pools;

    private void OnEnable()
    {
        GetPoolManager();
    }
    public void GetPoolManager()
    {
        keyValue = new Dictionary<ObjectTag, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> Object = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                obj.transform.localPosition = transform.position;
                Object.Enqueue(obj);
            }
            keyValue.Add(pool.objectTag, Object);
        }
    }

    public GameObject ActivePoolObject(ObjectTag poolTag, Transform player)
    {
        if (!keyValue.ContainsKey(poolTag))
        {
            return null;
        }

        GameObject obj = keyValue[poolTag].Dequeue();
        obj.SetActive(true);
        obj.transform.position = player.transform.position;
        obj.transform.rotation = player.transform.rotation;
        keyValue[poolTag].Enqueue(obj);
        return obj;

    }

    public GameObject ReturnPoolObject(ObjectTag tag, GameObject obj)
    {
        if (!keyValue.ContainsKey(tag))
        {
            return null;
        }

        keyValue[tag].Enqueue(obj);
        obj.SetActive(false);
        transform.parent = transform;
        obj.transform.position = transform.position;
        return obj;
    }
}
public enum ObjectTag
{
    Bullet
}
