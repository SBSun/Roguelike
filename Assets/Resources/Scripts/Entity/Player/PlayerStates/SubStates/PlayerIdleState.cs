using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, SO_PlayerData SO_PlayerData, string animBoolName) : base(player, stateMachine, SO_PlayerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (crouchInput)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
        }
    }
}
