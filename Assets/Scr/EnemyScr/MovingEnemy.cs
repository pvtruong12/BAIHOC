using Assets.Scr;
using UnityEngine;

public class MovingEnemy : PVTBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;


    protected override void loadComponents()
    {
        LoadEnemyCtrl();
    }
    private void LoadEnemyCtrl()
    {
        if (enemyCtrl != null)
            return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected override void Update()
    {
        Moving();
    }
    private void Moving()
    {
        bool flag = enemyCtrl.NavMeshAgent.velocity.magnitude > 0.1f && enemyCtrl.NavMeshAgent.remainingDistance > enemyCtrl.NavMeshAgent.stoppingDistance;
        enemyCtrl.Animator.SetBool("isRuning", flag);
        if (Vector3.Distance(enemyCtrl.transform.position, enemyCtrl.PlayerCtrl.transform.position) >5f)
        {
            enemyCtrl.NavMeshAgent.SetDestination(enemyCtrl.PlayerCtrl.transform.position);
        }    
    }
}
