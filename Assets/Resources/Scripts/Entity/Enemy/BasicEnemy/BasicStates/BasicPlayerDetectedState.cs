using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerDetectedState : EnemyState
{
    private readonly BasicEnemy basicEnemy;
    private readonly SO_BasicEnemyData basicEnemyData;

    private bool isPlayerDetected;
    private int playerDirection;

    public BasicPlayerDetectedState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(basicEnemy, stateMachine, enemyData, animBoolName)
    { 
        this.basicEnemy = basicEnemy;
        basicEnemyData = (SO_BasicEnemyData) enemyData;
}

    public override void Enter()
    {
        base.Enter();
        Debug.Log(basicEnemy.transform.name + " : 플레이어 발견");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        
        isPlayerDetected = basicEnemy.CollisionSense.PlayerDetected;

        if(isPlayerDetected)
        {

            basicEnemy.Movement.PlayerDirectionFlip(playerDirection);
        }
        else
        {
            stateMachine.ChangeState(basicEnemy.IdleState);
        }


        basicEnemy.Movement.SetVelocityX(basicEnemyData.movementVelocity * playerDirection);
        
    }

    public void PlayerDirection(Collider2D playerCol)
    {
        if (Mathf.Abs(playerCol.transform.position.x - basicEnemy.transform.position.x) > playerCol.bounds.size.x)
        {
            //플레이어가 Enemy의 왼쪽에 있으면
            if (playerCol.transform.position.x < basicEnemy.transform.position.x)
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
