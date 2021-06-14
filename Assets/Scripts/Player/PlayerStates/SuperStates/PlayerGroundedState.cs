using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    //Input
    protected int xInput;
    private bool jumpInput;
    private bool grabinput;
    private bool dashInput;

    //Check
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingLedge;
    

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingLedge = player.CheckIfTouchingLedge();
    }

    public override void Enter()
    {
        base.Enter();
        SetInputVariable();
        player.JumpState.ResetAmountOfJumpsLeft();
        player.DashState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetInputVariable();

        if(jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if(!isGrounded)
        {
            //���� �ִٰ� �������� ������ ���ϵ��� ������ �� �ִ� �ִ�Ƚ���� ���ش�. 
            player.JumpState.DecreaseAmountOfJumpsLeft(playerData.amountOfJumps);
            stateMachine.ChangeState(player.InAirState);
        }
        //���� ��� �ִ� ���� && GrabŰ ���� && �Ӹ� �տ��� ���� �־����
        else if(isTouchingWall && grabinput && isTouchingLedge)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if(dashInput && player.DashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetInputVariable()
    {
        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        grabinput = player.InputHandler.GrabInput;
        dashInput = player.InputHandler.DashInput;
    }
}
