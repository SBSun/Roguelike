using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_PlayerDiscoverState : EnemyState
{
    protected LandAttackEnemy landAttackEnemy;

    protected bool isTouchingWallFront;
    protected bool isCliffing;
    protected bool isPlayerDetected;
    protected bool isPlayerInAttackArea;

    public LandAttack_PlayerDiscoverState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.landAttackEnemy = landAttackEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        landAttackEnemy.EnemyHpBar.ActiveHpBar();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = landAttackEnemy.CollisionSense.WallFront;
        isCliffing = landAttackEnemy.CollisionSense.Cliffing;
        isPlayerDetected = landAttackEnemy.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = landAttackEnemy.CollisionSense.PlayerInAttackArea;

        if (!isPlayerDetected)
        {
            landAttackEnemy.EnemyHpBar.InactiveHpBar();
            stateMachine.ChangeState(landAttackEnemy.IdleState);
        }

        else if (isPlayerDetected && isPlayerInAttackArea && landAttackEnemy.AttackState.CheckAttackCoolTime())
            stateMachine.ChangeState(landAttackEnemy.AttackState);
    }


    public bool CheckPlayerFollow()
    {
        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            return true;
        else
            return false;
    }
}
