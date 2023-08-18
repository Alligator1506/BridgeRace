using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : IState<EnemyController>
{
    int targetBrick;

    public void OnEnter(EnemyController t)
    {
        targetBrick = Random.Range(2, 9);
        SeekTarget(t);
    }

    public void OnExcute(EnemyController t)
    {
        if (t.IsDestionation)
        {
            if (t.BrickCount >= targetBrick)
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                SeekTarget(t);
            }
        }
    }

    public void OnExit(EnemyController t)
    {

    }

    private void SeekTarget(EnemyController t)
    {
        Debug.Log(t.stage == null);
        if (t.stage != null)
        {
            Brick brick = t.stage.SeekBrickPoint(t.colorType);
            if (brick == null)
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                Debug.Log(brick.transform.position);
                t.SetDestination(brick.transform.position);
            }
        }
        else
        {
            Debug.Log(t.transform.position);
            t.SetDestination(t.transform.position);
        }
    }
}
