using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIdleState : EnemyState
{
    protected float idleTime;
    protected bool isIdleTimeOver;

    public BasicIdleState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(enemyData.minIdleTime, enemyData.maxIdleTime);
    }
}
