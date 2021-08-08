using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;

    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        //������ ����
        SetHoldPosition();
        HoldPosition();
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
            HoldPosition();
            if (yInput > 0) //Grab���¿��� ����Ű ��Ű�� ������ �� ������ ���·� ��ȯ
                stateMachine.ChangeState(player.WallClimbState);
            else if (yInput < 0 || !grabInput)
                stateMachine.ChangeState(player.WallSlideState);
        }
    }

    public void HoldPosition()
    {
        player.SetGravityScale(0);
        player.transform.position = holdPosition;
        player.Core.Movement.SetVelocityZero();
    }

    public void SetHoldPosition()
    {
        holdPosition = player.transform.position;
    }

}
