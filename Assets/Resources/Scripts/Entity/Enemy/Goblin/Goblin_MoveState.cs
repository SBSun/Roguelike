using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_MoveState : EnemyMoveState
{
    private Goblin goblin;

    public Goblin_MoveState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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

        if (isTouchingWall)
        {
            core.Movement.Flip();
            stateMachine.ChangeState(goblin.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
  
}
