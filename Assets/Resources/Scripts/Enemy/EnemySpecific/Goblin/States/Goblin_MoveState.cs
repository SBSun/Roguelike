using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_MoveState : EnemyState
{
    private Goblin goblin;
    private D_E_MoveState stateData;

    private bool isTouchingWallFront;
    private bool isTouchingWallBack;
    private bool isCliffing;
    private bool isPlayerDetected;

    private float moveTime;

    private int moveDirection;

    public Goblin_MoveState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isTouchingWallBack = goblin.CollisionSense.WallBack;
        isPlayerDetected = false;

        //뒤에 벽이 있으면 방향을 변경하지 않는다.
        if (goblin.CollisionSense.WallBack)
        {
            moveDirection = goblin.Movement.FacingDirection;
        }
        else
            SetRandomMoveDirection();

        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();

        goblin.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = goblin.CollisionSense.WallFront;
        isCliffing = goblin.CollisionSense.Cliffing;
        isPlayerDetected = goblin.CollisionSense.PlayerDetected;

        goblin.Movement.SetVelocityX(stateData.movementVelocity * moveDirection);

        if (Time.time > startTime + moveTime)
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
        //앞에 벽이 있거나 땅이 없으면
        else if (isTouchingWallFront || isCliffing)
        {
            goblin.Movement.Flip();
            moveDirection = goblin.Movement.FacingDirection;
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(goblin.PlayerDetectedState);
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

        if (moveDirection != goblin.Movement.FacingDirection)
            goblin.Movement.Flip();
    }
}
