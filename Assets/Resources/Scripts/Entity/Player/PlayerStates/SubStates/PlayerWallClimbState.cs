using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetGravityScale(0);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetGravityScale(playerData.defaultGravity);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            //����Ű ��Ű�� ������ ������ wallClimbVelocity�� ��ŭ ���� �̵�
            player.Core.Movement.SetVelocityY(playerData.wallClimbVelocity); 
            //����Ű ��Ű�� ������ ���� ������ WallGrabState�� ��ȯ
            if (yInput != 1)
                stateMachine.ChangeState(player.WallGrabState);
        }
    }
}
