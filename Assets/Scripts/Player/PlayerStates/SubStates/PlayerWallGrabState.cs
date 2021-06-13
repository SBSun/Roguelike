using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        //������ ����
        player.SetHoldPosition();
        player.HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
        player.SetGravityScale(playerData.defaultGravity);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.HoldPosition();
            if (yInput > 0) //Grab���¿��� ����Ű ��Ű�� ������ �� ������ ���·� ��ȯ
                stateMachine.ChangeState(player.WallClimbState);
            else if (yInput < 0 || !grabInput)
                stateMachine.ChangeState(player.WallSlideState);
        }
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
