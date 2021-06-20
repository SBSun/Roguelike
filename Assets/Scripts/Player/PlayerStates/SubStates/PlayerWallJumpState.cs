using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int wallJumpDirection;
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        core.Movement.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, wallJumpDirection);
        core.Movement.CheckIfShouldFlip(wallJumpDirection);
        player.JumpState.DecreaseAmountOfJumpsLeft(playerData.amountOfJumps);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
        player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));

        //wallJumpTime 시간을 더하여 다음 state로 바뀔 시간을 조정한다. 0.1초로 설정하면 점프 한 뒤 0.1초만에 inAirState로 변경되어 제자리에 멈추어 떨어짐
        if(Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }
    
    public void DetermineWallJumpDirection(bool isTouchingWall)
    {
        if(isTouchingWall)
        {
            wallJumpDirection = -core.Movement.FacingDirection;
        }
        else
        {
            wallJumpDirection = core.Movement.FacingDirection;
        }
    }
}
