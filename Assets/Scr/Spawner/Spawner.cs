using Assets.Scr;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner <T>: PVTBehaviour where T : PoolObj
{
    [SerializeField]protected List<T> listPool;


    public Transform Spawn(Transform prefabs)
    {
        Transform transform = Instantiate(prefabs);
        return transform;
    }
    public T Spawn(T prefabs)
    {
        T transform = GetObjectFormPool(prefabs);
        if (listPool != null)
        {
            return transform;
        }
        transform = Instantiate(prefabs);
        return transform;
    }
    public T Spawn(T prefabs, Vector3 possiton)
    {
        T transform = Spawn(prefabs);
        return transform;
    }
    public void UpdateName(T prefab, T newPrefabs) => newPrefabs.name = prefab.name;
    public void DeSpawner(T Obj)
    {
        if(Obj is MonoBehaviour mono)
        {
            mono.gameObject.SetActive(false);
            AddObjectToPool(Obj);
        }
    }
    private T GetObjectFormPool(T Obj)
    {
        foreach(T pool in listPool)
        {
            if(Obj.name ==  pool.name)
            {
                RemoObjectToPool(pool);
                return pool;
            }
        }
        return null;

    }
    protected void RemoObjectToPool(T obj)
    {
        listPool.Remove(obj);
    }
    protected void AddObjectToPool(T obj)
    {
        listPool.Add(obj);
    }
}
