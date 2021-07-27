using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_PlayerDetectedState : EnemyState
{
    protected Skeleton skeleton;

    protected bool isTouchingWallFront;
    protected bool isCliffing;
    protected bool isPlayerDetected;
    protected bool isPlayerInAttackArea;

    public Skeleton_PlayerDetectedState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName) : base(skeleton, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
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

        isTouchingWallFront = skeleton.CollisionSense.WallFront;
        isCliffing = skeleton.CollisionSense.Cliffing;
        isPlayerDetected = skeleton.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = skeleton.CollisionSense.PlayerInAttackArea;

        if (!isPlayerDetected)
        {
            stateMachine.ChangeState(skeleton.IdleState);
        }

        else if (isPlayerDetected && isPlayerInAttackArea && skeleton.AttackState.CheckAttackCoolTime())
            stateMachine.ChangeState(skeleton.AttackState);
    }


    public bool CheckPlayerFollow()
    {
        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            return true;
        else
            return false;
    }
}
