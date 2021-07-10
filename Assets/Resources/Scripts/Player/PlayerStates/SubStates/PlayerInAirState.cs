using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    //Input
    private int xInput;
    private bool jumpInput;
    private bool grabInput;
    private bool jumpInputStop;
    private bool dashInput;
    //Check
    private bool isJumping;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool isTouchingLedge;
    private bool isGrounded;
   
   
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CollisionSense.Grounded;
        isTouchingWall = player.CollisionSense.WallFront;
        isTouchingWallBack = player.CollisionSense.WallBack;
        isTouchingLedge = player.CollisionSense.Ledge;

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

        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetInputVariable();

        CheckJumpMultiplier();

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        //���� ���� -> LandState
        else if (isGrounded && player.Movement.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        //ĳ���� �տ� ���� �ְ� && ĳ���� �Ӹ� �տ� ���� ������
        else if(isTouchingWall && !isTouchingLedge)
        {
            stateMachine.ChangeState(player.LedgeClimbState);
        }
        //���� Ű ���� && ĳ���Ͱ� ���� ��� ������ -> WallJumpState
        else if (jumpInput && (isTouchingWall || isTouchingWallBack))
        {
            isTouchingWall = player.CollisionSense.WallFront;
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        //���� Ű ���� && ���� ���� Ƚ���� ���� ������ -> JumpState
        else if(jumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        //Grab Ű ���� && ĳ���� �� ���� ���� ��� ������ -> WallGrapState
        else if(isTouchingWall && grabInput && isTouchingLedge)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        //���� �¿� ����� ĳ���Ͱ� ���� �ִ� ������ ���� && ĳ���� �տ� ���� ������ -> WallSlideState
        else if(isTouchingWall && xInput == player.Movement.FacingDirection && player.Movement.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else if(dashInput && player.DashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        //�ƹ� ���� ��ȯ�� ����
        else
        {
            player.Movement.CheckIfShouldFlip(xInput);
            player.Movement.SetVelocityX(playerData.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", player.Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.Movement.CurrentVelocity.x));
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //����Ű�� ª�� ������ ª�� ���� ��� ������ ��� ����
    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.Movement.SetVelocityY(player.Movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.Movement.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }

    public void SetIsJumping() => isJumping = true;

    public void SetInputVariable()
    { 
        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        grabInput = player.InputHandler.GrabInput;
        dashInput = player.InputHandler.DashInput;
    }
}
