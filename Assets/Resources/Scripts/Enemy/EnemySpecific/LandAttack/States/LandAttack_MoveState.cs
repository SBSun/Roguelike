using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_MoveState : EnemyState
{
    private LandAttackEnemy landAttackEnemy;
    private D_E_MoveState stateData;

    private bool isTouchingWallFront;
    private bool isTouchingWallBack;
    private bool isCliffing;
    private bool isPlayerDetected;

    private float moveTime;

    private int moveDirection;

    public LandAttack_MoveState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.landAttackEnemy = landAttackEnemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isTouchingWallBack = landAttackEnemy.CollisionSense.WallBack;
        isPlayerDetected = false;

        //뒤에 벽이 있으면 방향을 변경하지 않는다.
        if (landAttackEnemy.CollisionSense.WallBack)
        {
            moveDirection = landAttackEnemy.Movement.FacingDirection;
        }
        else
            SetRandomMoveDirection();

        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();

        landAttackEnemy.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = landAttackEnemy.CollisionSense.WallFront;
        isCliffing = landAttackEnemy.CollisionSense.Cliffing;
        isPlayerDetected = landAttackEnemy.CollisionSense.PlayerDetected;

        landAttackEnemy.Movement.SetVelocityX(stateData.movementVelocity * moveDirection);

        if (Time.time > startTime + moveTime)
            stateMachine.ChangeState(landAttackEnemy.IdleState);
        //앞에 벽이 있거나 땅이 없으면
        else if (isTouchingWallFront || isCliffing)
        {
            landAttackEnemy.Movement.Flip();
            moveDirection = landAttackEnemy.Movement.FacingDirection;
        }
        else if (isPlayerDetected)
            stateMachine.ChangeState(landAttackEnemy.PlayerFollowState);
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

        if (moveDirection != landAttackEnemy.Movement.FacingDirection)
            landAttackEnemy.Movement.Flip();
    }
}
