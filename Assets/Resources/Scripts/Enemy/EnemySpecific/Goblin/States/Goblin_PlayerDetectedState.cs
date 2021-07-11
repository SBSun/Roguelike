using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerDetectedState : EnemyState
{
    private Goblin goblin;
    private D_Goblin enemyData;

    private bool isPlayerDetected;
    private int playerDirection;
    public Goblin_PlayerDetectedState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_Goblin enemyData) : base(goblin, stateMachine, animBoolName, enemyData)
    {
        this.goblin = goblin;
        this.enemyData = enemyData;
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

        if (isPlayerDetected)
        {

            goblin.Movement.PlayerDirectionFlip(playerDirection);
        }
        else
        {
            stateMachine.ChangeState(goblin.IdleState);
        }


        //basicEnemy.Movement.SetVelocityX(basicEnemyData.movementVelocity * playerDirection);
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
