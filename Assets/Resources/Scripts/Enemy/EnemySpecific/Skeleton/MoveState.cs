using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState, IMovable
{
    public MoveState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_Enemy enemyData) : base(enemy, stateMachine, animBoolName, enemyData)
    {
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

        Move();
    }

    public void Move()
    {

    }
}
