using Assets.Scr;
using UnityEngine;

public abstract class PoolObj : PVTBehaviour
{
    [SerializeField] protected DespawnerBase despawnerBase;
    public DespawnerBase DespawnerBase;

    protected override void loadComponents()
    {
        LoadDeSpawnBase();
    }
    private void LoadDeSpawnBase()
    {
        if (despawnerBase != null)
            return;
        despawnerBase = GetComponentInChildren<DespawnerBase>();
    }
}
