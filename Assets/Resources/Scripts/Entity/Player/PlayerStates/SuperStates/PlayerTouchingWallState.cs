using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected int xInput;
    protected int yInput;
    protected bool grabInput;
    protected bool jumpInput;
    protected bool isTouchingLedge;

    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.Core.CollisionSense.Grounded;
        isTouchingWall = player.Core.CollisionSense.WallFront;
        isTouchingLedge = player.Core.CollisionSense.Ledge;

        if(isTouchingWall && !isTouchingLedge)
        {
            player.LedgeClimbState.SetDetectedPosition(player.transform.position);
        }
    }

    public override void Enter()
    {
        base.Enter();

        SetInputVariable();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetInputVariable();
        //���� Ű�� ���� -> WallJumpState
        if(jumpInput)
        {
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        //���� ��� && grabŰ�� ������ ������ -> IdleState
        else if(isGrounded && !grabInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        //ĳ���� �տ� ���� ���ų� || ����Ű�� �� ������ ������ ���� ������ -> InAirState
        else if(!isTouchingWall || (xInput != player.Core.Movement.FacingDirection && !grabInput))
        {
            stateMachine.ChangeState(player.InAirState);
        }
        //ĳ���� �� �տ� ���� �ְ� && �Ӹ� �տ� ������
        else if(isTouchingWall && !isTouchingLedge)
        {
            stateMachine.ChangeState(player.LedgeClimbState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetInputVariable()
    {
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        grabInput = player.InputHandler.GrabInput;
        jumpInput = player.InputHandler.JumpInput;
    }
}
