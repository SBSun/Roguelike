using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_PlayerFollowState : LandAttack_PlayerDiscoverState
{
    private D_E_MoveState stateData;

    public LandAttack_PlayerFollowState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(landMoveAttackEnemy, stateMachine, animBoolName)
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
            stateMachine.ChangeState(landMoveAttackEnemy.PlayerLookForState);
        }

        landMoveAttackEnemy.Core.Movement.PlayerDirectionFlip(landMoveAttackEnemy.PlayerDirection);
        landMoveAttackEnemy.Core.Movement.SetVelocityX(stateData.movementVelocity * landMoveAttackEnemy.PlayerDirection);
    }
}
