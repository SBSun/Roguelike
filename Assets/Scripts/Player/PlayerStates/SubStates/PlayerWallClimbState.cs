using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            Debug.Log(player.CurrentVelocity.y);

            if (yInput != 1)
            {
                Debug.Log(player.CurrentVelocity.y);
                stateMachine.ChangeState(player.WallGrabState);
            }
            else if(yInput == 1)
                player.SetVelocityY(playerData.wallClimbVelocity);
            Debug.Log(player.CurrentVelocity.y);
        }
    }
}
