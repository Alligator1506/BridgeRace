using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Character
{
    [SerializeField] private Animator animator;
    //[SerializeField] protected Transform tf;
    //keo navmesh agent vao
    [SerializeField] private NavMeshAgent agent;
    //luu diem muc tieu se di den
    private Vector3 destination;
    protected override void Start()
    {
        base.Start();
        ChangeState(new PatrolState());
    }

    //property tra ve ket qua xem la da toi diem muc tieu hay chua
    //public bool IsDestionation => Vector3.Distance(tf.position, destination + (tf.position.y - destination.y) * Vector3.up) < 0.1f;
    public bool IsDestionation => Vector3.Distance(destination, transform.position) < 0.1f;
    public void SetDestination(Vector3 position)
    {
        this.destination = position;
        //destination.y = 0;
        agent.SetDestination(position);
    }

    IState<EnemyController> currentState;

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);
            CanMove(transform.position);
        }     
    }

    public void ChangeState(IState<EnemyController> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }


}
