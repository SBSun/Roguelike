using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_IdleState : EnemyIdleState
{
    private Goblin goblin;

    public Goblin_IdleState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
        goblin = (Goblin)enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isIdleTimeOver)
        {
            stateMachine.ChangeState(goblin.MoveState); 
        }
    }
}
