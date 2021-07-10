using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPos;
    private Vector2 cornerPos;
    private Vector2 startPos;
    private Vector2 stopPos;
    private Vector2 workSpace;

    private bool isHanging;
    private bool isClimbing;
    private bool isTouchingCeiling;

    private int xInput;
    private int yInput;
    private bool jumpInput;
    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();

        player.Movement.SetVelocityZero();
        player.Movement.SetGravityScale(0);
        player.transform.position = detectedPos;
        cornerPos = DetermineCornerPosition();

        startPos.Set(cornerPos.x - (player.Movement.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);
        stopPos.Set(cornerPos.x + (player.Movement.FacingDirection * playerData.stopOffset.x), cornerPos.y + playerData.stopOffset.y);

        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();
        player.Movement.SetGravityScale(playerData.defaultGravity);
        if (isHanging)
        {
            player.Anim.SetBool(animBoolName, false);
            isHanging = false;
        }


        if(isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }    
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //�ִϸ��̼��� ������ -> IdleState
        if(isAnimationFinished)
        {
            if (isTouchingCeiling)
                stateMachine.ChangeState(player.CrouchIdleState);
            else
                stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;

            player.Movement.SetVelocityZero();
            player.transform.position = startPos;

            if (xInput == player.Movement.FacingDirection && isHanging && !isClimbing)
            {
                CheckForSpace();
                isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if (yInput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else if(jumpInput && !isClimbing)
            {
                player.WallJumpState.DetermineWallJumpDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }
        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

    //�ö� ���� õ�� ���̰� ĳ���Ͱ� ���� ���̸� LedgeClimbCrouch �ִϸ��̼����� ����
    private void CheckForSpace()
    {
        isTouchingCeiling = Physics2D.Raycast(cornerPos, Vector2.up, playerData.standColliderHeight,player.CollisionSense.WhatIsGround);
        player.Anim.SetBool("isTouchingCeiling", isTouchingCeiling);
    }

    private Vector2 DetermineCornerPosition()
    {
        //ĳ���Ϳ� ���� ���� ���� ���ϱ�
        RaycastHit2D xHit = Physics2D.Raycast(player.CollisionSense.WallCheck.position, Vector2.right * player.Movement.FacingDirection, player.CollisionSense.WallCheckDistance, player.CollisionSense.WhatIsGround);
        float xDist = xHit.distance;
        //ĳ���Ϳ� �� ���� ���� + 0.01(������ ���� ��� �ϱ� ���� ����) * ĳ���� ����  
        workSpace.Set((xDist + 0.01f) * player.Movement.FacingDirection, 0f);
        //ledgeCheck.y�� ���� ���� ���� ���ϱ�
        RaycastHit2D yHit = Physics2D.Raycast(player.CollisionSense.LedgeCheck.position + (Vector3)workSpace, Vector2.down, player.CollisionSense.LedgeCheck.position.y - player.CollisionSense.WallCheck.position.y, player.CollisionSense.WhatIsGround);

        workSpace.Set(yHit.point.x, yHit.point.y);
        return workSpace;
    }
}
