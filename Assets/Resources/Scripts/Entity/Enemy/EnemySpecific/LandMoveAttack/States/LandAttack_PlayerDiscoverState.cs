using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_PlayerDiscoverState : EnemyState
{
    protected LandMoveAttackEnemy landMoveAttackEnemy;

    protected bool isTouchingWallFront;
    protected bool isCliffing;
    protected bool isPlayerDetected;
    protected bool isPlayerInAttackArea;

    public LandAttack_PlayerDiscoverState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(landMoveAttackEnemy, stateMachine, animBoolName)
    {
        this.landMoveAttackEnemy = landMoveAttackEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        landMoveAttackEnemy.EnemyHpBar.ActiveHpBar();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = landMoveAttackEnemy.Core.CollisionSense.WallFront;
        isCliffing = landMoveAttackEnemy.Core.CollisionSense.Cliffing;
        isPlayerDetected = landMoveAttackEnemy.PlayerDetected;
        isPlayerInAttackArea = landMoveAttackEnemy.PlayerInAttackArea;

        if (!isPlayerDetected)
        {
            landMoveAttackEnemy.EnemyHpBar.InactiveHpBar();
            stateMachine.ChangeState(landMoveAttackEnemy.IdleState);
        }

        else if (isPlayerDetected && isPlayerInAttackArea && landMoveAttackEnemy.AttackState.CheckAttackCoolTime())
            stateMachine.ChangeState(landMoveAttackEnemy.AttackState);
    }


    public bool CheckPlayerFollow()
    {
        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            return true;
        else
            return false;
    }
}
