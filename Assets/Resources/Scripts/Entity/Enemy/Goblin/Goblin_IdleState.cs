using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_IdleState : EnemyIdleState
{
    private Goblin goblin;

    private float idleTime;

    public Goblin_IdleState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
        goblin = (Goblin)enemy;
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
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
            stateMachine.ChangeState(goblin.MoveState);
        }
    }
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(enemyData.minIdleTime, enemyData.maxIdleTime);
    }
}
