using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_DamagedState : EnemyDamagedState
{
    Skeleton skeleton;

    private bool isTouchingWallFront;
    private bool isCliffing;
    private bool isPlayerInAttackArea;

    public Skeleton_DamagedState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName, D_E_DamagedState stateData) : base(skeleton, stateMachine, animBoolName, stateData)
    {
        this.skeleton = skeleton;   
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

        isTouchingWallFront = skeleton.CollisionSense.WallFront;
        isCliffing = skeleton.CollisionSense.Cliffing;
        isPlayerInAttackArea = skeleton.CollisionSense.PlayerInAttackArea;

        if (isStunTimeOver)
        {
            if (isTouchingWallFront || isCliffing || isPlayerInAttackArea)
                stateMachine.ChangeState(skeleton.PlayerLookForState);
            else
                stateMachine.ChangeState(skeleton.PlayerFollowState);
        }
    }
}
