using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    public PlayerCrouchMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.CheckIfShouldFlip(xInput);
        core.Movement.SetVelocityX(playerData.crouchMovementVelocity * xInput);
        core.Movement.SetColliderHeight(playerData.crouchColliderHeight);
    }
    public override void Exit()
    {
        base.Exit();

        core.Movement.SetColliderHeight(playerData.standColliderHeight);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            core.Movement.CheckIfShouldFlip(xInput);

            core.Movement.SetVelocityX(playerData.crouchMovementVelocity * xInput);

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
