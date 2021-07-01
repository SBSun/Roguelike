using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveState : EnemyState
{

    protected bool isTouchingWallFront;
    protected bool isCliffing;

    protected float moveTime;

    protected int moveDirection;

    private readonly BasicEnemy basicEnemy;
    protected BasicEnemyCollisionSense collisionSense;

    public BasicMoveState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName, BasicEnemyCollisionSense collisionSense) : base(basicEnemy, stateMachine, enemyData, animBoolName)
    {
        this.basicEnemy = basicEnemy;
        this.collisionSense = collisionSense;
    }


    public override void Enter()
    {
        base.Enter();

        //뒤에 벽이 있으면 방향을 변경하지 않는다.
        if (collisionSense.WallBack)
            moveDirection = enemy.Core.Movement.FacingDirection;
        else
            SetRandomMoveDirection();

        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            isTouchingWallFront = collisionSense.WallFront;
            isCliffing = collisionSense.Cliffing;

            core.Movement.SetVelocityX(enemyData.movementVelocity * moveDirection);

            if (Time.time > startTime + moveTime)
            {
                stateMachine.ChangeState(basicEnemy.IdleState);
            }
            //앞에 벽이 있거나 땅이 없으면
            else if (isTouchingWallFront || isCliffing)
            {
                core.Movement.Flip();
                stateMachine.ChangeState(basicEnemy.IdleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetRandomMoveTime()
    {
        moveTime = Random.Range(enemyData.minMoveTime, enemyData.maxMoveTime);
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
