using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected D_EnemyIdleState stateData;

    private readonly BasicEnemy basicEnemy;

    private float idleTime;

    private bool isPlayerDetected;
    public EnemyIdleState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine ,string animBoolName, D_EnemyIdleState stateData) : base(basicEnemy, stateMachine, animBoolName)
    {
        this.basicEnemy = basicEnemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        basicEnemy.Movement.SetVelocityZero();
        isPlayerDetected = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            isPlayerDetected = basicEnemy.CollisionSense.PlayerDetected;

            if (Time.time >= startTime + idleTime)
            {

                stateMachine.ChangeState(basicEnemy.MoveState);
            }
            else if (isPlayerDetected)
            {
                stateMachine.ChangeState(basicEnemy.PlayerDetectedState);
            }
        }
    }
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }

    
}
