using Assets.Scr;
using UnityEngine;

public abstract class Despawner<T> : DespawnerBase where T : PoolObj
{
    [SerializeField]protected Spawner<T> _spawner;
    [SerializeField]protected T parent;

    protected override void loadComponents()
    {
        LoadParent();
    }
    private void LoadParent()
    {
        parent = transform.parent.GetComponent<T>();
    }
    public virtual void DeSpawn()
    {
        _spawner.DeSpawner(parent);
    }
    public void LoadSpawner()
    {
        if (_spawner != null)
            return;
        _spawner = FindAnyObjectByType<Spawner<T>>();
    }

   
}
