using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_PlayerLookForState : Skeleton_PlayerDetectedState
{
    public Skeleton_PlayerLookForState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName) : base(skeleton, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        skeleton.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            stateMachine.ChangeState(skeleton.PlayerFollowState);

        skeleton.Movement.SetVelocityZero();
    }
}
