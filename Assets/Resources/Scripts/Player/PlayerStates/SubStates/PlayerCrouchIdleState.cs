using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.Movement.SetVelocityZero();
        player.Movement.SetColliderHeight(playerData.crouchColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();

        player.Movement.SetColliderHeight(playerData.standColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            if(!crouchInput && !isTouchingCelling)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if(xInput != 0)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }
        }
    }
}