using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_MoveState : EnemyState
{
    private Goblin goblin;

    private bool isTouchingWall;
    private bool isCliffing;
    private bool isTouchingLedge;

    private float moveTime;

    private int moveDirection;

    public Goblin_MoveState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
        goblin = (Goblin)enemy;
    }

    public override void Enter()
    {
        base.Enter();

        //뒤에 벽이 있으면 방향을 변경하지 않는다.
        if (!goblin.CollisionSense.WallBack)
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

        isTouchingWall = goblin.CollisionSense.WallFront;
        //isCliffing = goblin.CollisionSense.Cliffing;
        //isTouchingLedge = goblin.CollisionSense.Ledge;

        core.Movement.SetVelocityX(enemyData.movementVelocity * moveDirection);

        if(Time.time > startTime + moveTime)
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
        else if (isTouchingWall || isCliffing || isTouchingLedge)
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
        Debug.Log(moveDirection);

        if (moveDirection != core.Movement.FacingDirection)
            core.Movement.Flip();
    }
}
