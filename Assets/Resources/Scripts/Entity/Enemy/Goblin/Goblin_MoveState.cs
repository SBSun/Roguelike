using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_MoveState : EnemyState
{
    private Goblin goblin;

    private bool isTouchingWallFront;
    private bool isCliffing;

    private float moveTime;

    private int moveDirection;

    public Goblin_MoveState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
        goblin = (Goblin)enemy;
    }

    public override void Enter()
    {
        base.Enter();

        //�ڿ� ���� ������ ������ �������� �ʴ´�.
        if (goblin.CollisionSense.WallBack)
            moveDirection = goblin.Core.Movement.FacingDirection;
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

        isTouchingWallFront = goblin.CollisionSense.WallFront;
        isCliffing = goblin.CollisionSense.Cliffing;

        core.Movement.SetVelocityX(enemyData.movementVelocity * moveDirection);

        if(Time.time > startTime + moveTime)
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
        //�տ� ���� �ְų� ���� ������
        else if (isTouchingWallFront || isCliffing)
        {
            core.Movement.Flip();
            stateMachine.ChangeState(goblin.IdleState);
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