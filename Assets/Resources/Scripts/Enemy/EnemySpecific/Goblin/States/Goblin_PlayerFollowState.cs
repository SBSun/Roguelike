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
            else if(!isCliffing && !isTouchingWallFront && CheckPlayerFollow())
            {
                goblin.Movement.PlayerDirectionFlip(goblin.CollisionSense.PlayerDirection);
                goblin.Movement.SetVelocityX(stateData.movementVelocity * goblin.CollisionSense.PlayerDirection);
            }
        }
        else
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
    }

    public bool CheckPlayerFollow()
    {
        //Enemy와 Player간의 거리가 Enemy의 콜라이더 사이즈보다 크면 따라간다
        if (Mathf.Abs(goblin.CollisionSense.playerCol.transform.position.x - goblin.transform.position.x) > goblin.CollisionSense.playerCol.bounds.size.x)
            return true;
        else
            return false;
    }
}
