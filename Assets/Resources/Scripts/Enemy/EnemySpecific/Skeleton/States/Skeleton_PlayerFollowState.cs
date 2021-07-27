using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_PlayerFollowState : Skeleton_PlayerDetectedState
{
    private D_E_MoveState stateData;

    public Skeleton_PlayerFollowState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(skeleton, stateMachine, animBoolName)
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
            stateMachine.ChangeState(skeleton.PlayerLookForState);
        }

        skeleton.Movement.PlayerDirectionFlip(skeleton.CollisionSense.PlayerDirection);
        skeleton.Movement.SetVelocityX(stateData.movementVelocity * skeleton.CollisionSense.PlayerDirection);
    }
}
