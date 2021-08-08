using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Core.Movement.CheckIfShouldFlip(xInput);
        player.Core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(!isExitingState)
        {
            player.Core.Movement.CheckIfShouldFlip(xInput);

            player.Core.Movement.SetVelocityX(playerData.movementVelocity * xInput);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if(crouchInput)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
        }
        
    }
}
