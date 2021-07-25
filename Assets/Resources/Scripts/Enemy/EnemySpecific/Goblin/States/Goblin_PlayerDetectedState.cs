using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerDetectedState : EnemyState
{
    protected Goblin goblin;

    protected bool isTouchingWallFront;
    protected bool isCliffing;
    protected bool isPlayerDetected;
    protected bool isPlayerInAttackArea;

    public Goblin_PlayerDetectedState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
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

        isTouchingWallFront = goblin.CollisionSense.WallFront;
        isCliffing = goblin.CollisionSense.Cliffing;
        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if (!isPlayerDetected)
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
        else if (isPlayerDetected && isPlayerInAttackArea && goblin.AttackState.CheckAttackCoolTime())
            stateMachine.ChangeState(goblin.AttackState);
    }

    public bool CheckPlayerFollow()
    {
        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            return true;
        else
            return false;

    }
}
