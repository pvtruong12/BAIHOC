using Assets.Scr;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyCtrl : PVTBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] protected NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    protected override void loadComponents()
    {
        LoadPlayerCtrl();
        LoadNavmesh();
        LoadAnimator();
    }
    private void LoadAnimator()
    {
        if (animator != null)
            return;
        animator = GetComponentInChildren<Animator>();
    }
    private void LoadNavmesh()
    {
        if (navMeshAgent != null)
            return;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null)
            return;
        playerCtrl = FindAnyObjectByType<PlayerCtrl>();
    }
}
