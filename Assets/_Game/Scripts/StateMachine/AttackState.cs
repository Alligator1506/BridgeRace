using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<EnemyController>
{
    public void OnEnter(EnemyController t)
    {
        Transform target = GameObject.Find("wfCube").transform;
        t.SetDestination(target.position);
    }

    public void OnExcute(EnemyController t)
    {
        if (t.BrickCount == 0)
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(EnemyController t)
    {

    }
}
