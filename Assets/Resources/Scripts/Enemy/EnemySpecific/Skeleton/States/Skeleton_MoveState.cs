using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_MoveState : EnemyState
{
    private Skeleton skeleton;
    private D_E_MoveState stateData;

    private bool isTouchingWallFront;
    private bool isTouchingWallBack;
    private bool isCliffing;
    private bool isPlayerDetected;

    private float moveTime;

    private int moveDirection;

    public Skeleton_MoveState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(skeleton, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isTouchingWallBack = skeleton.CollisionSense.WallBack;
        isPlayerDetected = false;

        //�ڿ� ���� ������ ������ �������� �ʴ´�.
        if (skeleton.CollisionSense.WallBack)
        {
            moveDirection = skeleton.Movement.FacingDirection;
        }
        else
            SetRandomMoveDirection();

        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();

        skeleton.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = skeleton.CollisionSense.WallFront;
        isCliffing = skeleton.CollisionSense.Cliffing;
        isPlayerDetected = skeleton.CollisionSense.PlayerDetected;

        skeleton.Movement.SetVelocityX(stateData.movementVelocity * moveDirection);

        if (Time.time > startTime + moveTime)
        {
            stateMachine.ChangeState(skeleton.IdleState);
        }
        //�տ� ���� �ְų� ���� ������
        else if (isTouchingWallFront || isCliffing)
        {
            skeleton.Movement.Flip();
            moveDirection = skeleton.Movement.FacingDirection;
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(skeleton.PlayerDetectedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetRandomMoveTime()
    {
        moveTime = Random.Range(stateData.minMoveTime, stateData.maxMoveTime);
    }

    public void SetRandomMoveDirection()
    {
        moveDirection = Random.Range(0, 2);

        if (moveDirection == 0)
            moveDirection = -1;

        if (moveDirection != skeleton.Movement.FacingDirection)
            skeleton.Movement.Flip();
    }
}
