using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    public PlayerCrouchMoveState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Movement.CheckIfShouldFlip(xInput);
        player.Movement.SetVelocityX(playerData.crouchMovementVelocity * xInput);
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

        if (!isExitingState)
        {
            player.Movement.CheckIfShouldFlip(xInput);

            player.Movement.SetVelocityX(playerData.crouchMovementVelocity * xInput);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else if (!crouchInput && !isTouchingCelling) 
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
