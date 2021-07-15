using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerDetectedState : EnemyState
{
    private Goblin goblin;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;
    private int playerDirection;
    public Goblin_PlayerDetectedState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
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
        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if (isPlayerDetected)
        {
            goblin.Movement.PlayerDirectionFlip(playerDirection);
            //goblin.Movement.SetVelocityX(enemyData.movementVelocity * playerDirection); MoveState에다가 구현
        }
        else if(!isPlayerDetected)
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
        else if(isPlayerInAttackArea)
        {

        }
    }

    public void PlayerDirection(Collider2D playerCol)
    {
        if (Mathf.Abs(playerCol.transform.position.x - goblin.transform.position.x) > playerCol.bounds.size.x)
        {
            //플레이어가 Enemy의 왼쪽에 있으면
            if (playerCol.transform.position.x < goblin.transform.position.x)
            {
                playerDirection = -1;
            }
            else
            {
                playerDirection = 1;
            }
        }
    }
}
