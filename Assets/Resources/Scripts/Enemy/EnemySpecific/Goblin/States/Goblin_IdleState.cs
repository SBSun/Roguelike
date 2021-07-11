using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_IdleState : EnemyState
{
    private Goblin goblin;
    private D_Goblin enemyData;

    private float idleTime;

    private bool isPlayerDetected;

    public Goblin_IdleState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_Goblin enemyData) : base(goblin, stateMachine, animBoolName, enemyData)
    {
        this.goblin = goblin;
        this.enemyData = enemyData;
    }

    public override void Enter()
    {
        base.Enter();

        goblin.Movement.SetVelocityZero();
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

        if (!isExitingState)
        {
            isPlayerDetected = goblin.CollisionSense.PlayerDetected;

            if (Time.time >= startTime + idleTime)
            {

                stateMachine.ChangeState(goblin.MoveState);
            }
            else if (isPlayerDetected)
            {
                stateMachine.ChangeState(goblin.PlayerDetectedState);
            }
        }
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(enemyData.minIdleTime, enemyData.maxIdleTime);
    }
}
