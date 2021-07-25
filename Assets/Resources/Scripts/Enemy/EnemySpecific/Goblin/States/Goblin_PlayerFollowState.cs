using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerFollowState : Goblin_PlayerDetectedState
{
    private D_E_MoveState stateData;

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

        if (isTouchingWallFront || isCliffing || isPlayerInAttackArea)
        {
            stateMachine.ChangeState(goblin.PlayerLookForState);
        }


        goblin.Movement.PlayerDirectionFlip(goblin.CollisionSense.PlayerDirection);
        goblin.Movement.SetVelocityX(stateData.movementVelocity * goblin.CollisionSense.PlayerDirection);
    }
}
