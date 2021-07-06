using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveState : EnemyState
{

    private bool isTouchingWallFront;
    private bool isTouchingWallBack;
    private bool isCliffing;
    private bool isPlayerDetected;

    private float moveTime;

    private int moveDirection;

    private readonly BasicEnemy basicEnemy;
    private readonly SO_BasicEnemyData basicEnemyData;

    public BasicMoveState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(basicEnemy, stateMachine, enemyData, animBoolName)
    {
        this.basicEnemy = basicEnemy;
        basicEnemyData = (SO_BasicEnemyData)enemyData;
    }


    public override void Enter()
    {
        base.Enter();

        isTouchingWallBack = basicEnemy.CollisionSense.WallBack;
        isPlayerDetected = false;

        //뒤에 벽이 있으면 방향을 변경하지 않는다.
        if (basicEnemy.CollisionSense.WallBack)
        {
            Debug.Log("벽 있음");
            moveDirection = enemy.Core.Movement.FacingDirection;
        }
        else
            SetRandomMoveDirection();

        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();

        core.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            isTouchingWallFront = basicEnemy.CollisionSense.WallFront;
            isCliffing = basicEnemy.CollisionSense.Cliffing;
            isPlayerDetected = basicEnemy.CollisionSense.PlayerDetected;

            core.Movement.SetVelocityX(basicEnemyData.movementVelocity * moveDirection);

            if (Time.time > startTime + moveTime)
            {
                stateMachine.ChangeState(basicEnemy.IdleState);
            }
            //앞에 벽이 있거나 땅이 없으면
            else if (isTouchingWallFront || isCliffing)
            {
                core.Movement.Flip();
                moveDirection = core.Movement.FacingDirection;
            }
            else if(isPlayerDetected)
            {
                stateMachine.ChangeState(basicEnemy.PlayerDetectedState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetRandomMoveTime()
    {
        moveTime = Random.Range(basicEnemyData.minMoveTime, basicEnemyData.maxMoveTime);
    }

    public void SetRandomMoveDirection()
    {
        moveDirection = Random.Range(0, 2);

        if (moveDirection == 0)
            moveDirection = -1;

        if (moveDirection != core.Movement.FacingDirection)
            core.Movement.Flip();
    }
}
