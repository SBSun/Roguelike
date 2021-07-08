using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, SO_PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Movement.SetGravityScale(0);
    }

    public override void Exit()
    {
        base.Exit();
        player.Movement.SetGravityScale(playerData.defaultGravity);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            //방향키 윗키를 누르고 있으면 wallClimbVelocity값 만큼 위로 이동
            player.Movement.SetVelocityY(playerData.wallClimbVelocity); 
            //방향키 윗키를 누르고 있지 않으면 WallGrabState로 변환
            if (yInput != 1)
                stateMachine.ChangeState(player.WallGrabState);
        }
    }
}
