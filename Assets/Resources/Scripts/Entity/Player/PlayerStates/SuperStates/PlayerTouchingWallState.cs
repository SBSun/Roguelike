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
        //점프 키를 누름 -> WallJumpState
        if(jumpInput)
        {
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        //땅에 닿고 && grab키를 누르지 않으면 -> IdleState
        else if(isGrounded && !grabInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        //캐릭터 앞에 벽이 없거나 || 방향키가 벽 방향을 누르고 있지 않으면 -> InAirState
        else if(!isTouchingWall || (xInput != player.Core.Movement.FacingDirection && !grabInput))
        {
            stateMachine.ChangeState(player.InAirState);
        }
        //캐릭터 몸 앞에 벽이 있고 && 머리 앞에 없으면
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
