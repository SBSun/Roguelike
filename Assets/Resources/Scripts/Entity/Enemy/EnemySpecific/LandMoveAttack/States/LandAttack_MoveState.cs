using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_MoveState : EnemyState
{
    private LandMoveAttackEnemy landMoveAttackEnemy;
    private D_E_MoveState stateData;

    private bool isTouchingWallFront;
    private bool isTouchingWallBack;
    private bool isCliffing;
    private bool isPlayerDetected;

    private float moveTime;

    private int moveDirection;

    public LandAttack_MoveState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(landMoveAttackEnemy, stateMachine, animBoolName)
    {
        this.landMoveAttackEnemy = landMoveAttackEnemy;
        this.stateData = stateData;
    }
    
    public override void Enter()
    {
        base.Enter();

        isTouchingWallBack = landMoveAttackEnemy.Core.CollisionSense.WallBack;
        isPlayerDetected = false;

        //뒤에 벽이 있으면 방향을 변경하지 않는다.
        if (landMoveAttackEnemy.Core.CollisionSense.WallBack)
        {
            moveDirection = landMoveAttackEnemy.Core.Movement.FacingDirection;
        }
        else
            SetRandomMoveDirection();

        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();

        landMoveAttackEnemy.Core.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = landMoveAttackEnemy.Core.CollisionSense.WallFront;
        isCliffing = landMoveAttackEnemy.Core.CollisionSense.Cliffing;
        isPlayerDetected = landMoveAttackEnemy.Core.CollisionSense.PlayerDetected;

        landMoveAttackEnemy.Core.Movement.SetVelocityX(stateData.movementVelocity * moveDirection);

        if (Time.time > startTime + moveTime)
            stateMachine.ChangeState(landMoveAttackEnemy.IdleState);
        //앞에 벽이 있거나 땅이 없으면
        else if (isTouchingWallFront || isCliffing)
        {
            landMoveAttackEnemy.Core.Movement.Flip();
            moveDirection = landMoveAttackEnemy.Core.Movement.FacingDirection;
        }
        else if (isPlayerDetected)
            stateMachine.ChangeState(landMoveAttackEnemy.PlayerFollowState);
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

        if (moveDirection != landMoveAttackEnemy.Core.Movement.FacingDirection)
            landMoveAttackEnemy.Core.Movement.Flip();
    }
}
