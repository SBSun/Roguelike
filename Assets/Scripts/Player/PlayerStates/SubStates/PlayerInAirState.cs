using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool grabInput;
    private bool jumpInputStop;
    private bool isJumping;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingWallBack = player.CheckIfTouchingWallBack();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        grabInput = player.InputHandler.GrabInput;

        CheckJumpMultiplier();

        //땅에 착지 -> LandState
        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        //점프 키 누름 && 캐릭터가 벽에 닿아 있으면 -> WallJumpState
        else if (jumpInput && (isTouchingWall || isTouchingWallBack))
        {
            isTouchingWall = player.CheckIfTouchingWall();
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        //점프 키 누름 && 점프 가능 횟수가 남아 있으면 -> JumpState
        else if(jumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        //Grab 키 누름 && 캐릭터 앞 쪽이 벽에 닿아 있으면 -> WallJumpState
        else if(isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        //누른 좌우 방향과 캐릭터가 보고 있는 방향이 같고 && 캐릭터 앞에 벽이 있으면 -> WallSlideState
        else if(isTouchingWall && xInput == player.FacingDirection && player.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        //아무 상태 변환이 없음
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //점프키를 짧게 누르면 짧게 점프 길게 누르면 길게 점프
    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }

    public void SetIsJumping() => isJumping = true;
}
