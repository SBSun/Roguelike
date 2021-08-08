using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_PlayerFollowState : LandAttack_PlayerDiscoverState
{
    private D_E_MoveState stateData;

    public LandAttack_PlayerFollowState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
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

        if (isTouchingWallFront || isCliffing || isPlayerInAttackArea)
        {
            stateMachine.ChangeState(landAttackEnemy.PlayerLookForState);
        }

        landAttackEnemy.Core.Movement.PlayerDirectionFlip(landAttackEnemy.Core.CollisionSense.PlayerDirection);
        landAttackEnemy.Core.Movement.SetVelocityX(stateData.movementVelocity * landAttackEnemy.Core.CollisionSense.PlayerDirection);
    }
}
