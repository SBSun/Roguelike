using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIdleState : EnemyState
{
    private readonly BasicEnemy basicEnemy;
    private readonly SO_BasicEnemyData basicEnemyData;

    private float idleTime;

    private bool isPlayerDetected;
    public BasicIdleState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(basicEnemy, stateMachine, enemyData, animBoolName)
    {
        this.basicEnemy = basicEnemy;
        basicEnemyData = (SO_BasicEnemyData)enemyData;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityZero();
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
            else if(isPlayerDetected)
            {
                stateMachine.ChangeState(basicEnemy.PlayerDetectedState);
            }
        }
    }
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(basicEnemyData.minIdleTime, basicEnemyData.maxIdleTime);
    }

    
}
