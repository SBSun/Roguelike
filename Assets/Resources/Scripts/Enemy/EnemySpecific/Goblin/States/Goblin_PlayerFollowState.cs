using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerFollowState : EnemyState
{
    private Goblin goblin;
    private D_E_MoveState stateData;

    private bool isTouchingWallFront;
    private bool isCliffing;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    private int playerDirection;

    public Goblin_PlayerFollowState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
        this.stateData = stateData;
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

        isTouchingWallFront = goblin.CollisionSense.WallFront;
        isCliffing = goblin.CollisionSense.Cliffing;

        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if(isPlayerDetected)
        {
            if(isPlayerInAttackArea && goblin.AttackState.CheckAttackCoolTime())
            {
                stateMachine.ChangeState(goblin.AttackState);
            }
            else if(!isCliffing && !isTouchingWallFront)
            {
                playerDirection = goblin.CollisionSense.PlayerDirection;
                goblin.Movement.PlayerDirectionFlip(playerDirection);
                goblin.Movement.SetVelocityX(stateData.movementVelocity * playerDirection);
            }
        }
        else
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
    }

}
