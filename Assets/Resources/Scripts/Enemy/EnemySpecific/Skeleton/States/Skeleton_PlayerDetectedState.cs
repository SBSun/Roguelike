using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_PlayerDetectedState : EnemyState
{
    private Skeleton skeleton;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;
    private int playerDirection;

    public Skeleton_PlayerDetectedState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName) : base(skeleton, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
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
        isPlayerDetected = skeleton.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = skeleton.CollisionSense.PlayerInAttackArea;

        if (isPlayerDetected)
        {
            skeleton.Movement.PlayerDirectionFlip(playerDirection);
        }
        else if(isPlayerInAttackArea)
        {

        }
        else
        {
            stateMachine.ChangeState(skeleton.IdleState);
        }


        //basicEnemy.Movement.SetVelocityX(basicEnemyData.movementVelocity * playerDirection);
    }

    public void PlayerDirection(Collider2D playerCol)
    {
        if (Mathf.Abs(playerCol.transform.position.x - skeleton.transform.position.x) > playerCol.bounds.size.x)
        {
            //플레이어가 Enemy의 왼쪽에 있으면
            if (playerCol.transform.position.x < skeleton.transform.position.x)
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
