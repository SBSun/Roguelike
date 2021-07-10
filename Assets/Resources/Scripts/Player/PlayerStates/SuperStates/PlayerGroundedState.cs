using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    //Input
    protected int xInput;
    protected bool jumpInput;
    protected bool grabinput;
    protected bool dashInput;
    protected bool crouchInput;

    //Check
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool isTouchingLedge;
    protected bool isTouchingCelling;
    

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CollisionSense.Grounded;
        isTouchingWall = player.CollisionSense.WallFront;
        isTouchingLedge = player.CollisionSense.Ledge;
        isTouchingCelling = player.CollisionSense.Ceiling;
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

        //AttackŰ ����
        if(player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !isTouchingCelling)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if(player.InputHandler.AttackInputs[(int)CombatInputs.secondary] && !isTouchingCelling)
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if(jumpInput && player.JumpState.CanJump())
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
        crouchInput = player.InputHandler.CrouchInput;
    }
}
