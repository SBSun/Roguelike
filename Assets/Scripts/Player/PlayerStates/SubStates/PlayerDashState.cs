using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }
    private bool isHolding;

    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    private Vector2 lastAfterImagePos;

    private bool isGrounded;
    private bool dashInputStop;
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        //Dash 못하게 막음
        CanDash = false;
        player.InputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * player.FacingDirection;

        //느려지게 함
        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime; //timeScale 영향을 받지 않음

        //화살표 이미지 활성화
        player.DashDirectionIndicator.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocityY(0f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));

            if(isHolding)
            {
                if(isGrounded)
                {

                }

                //방향 설정
                dashDirectionInput = player.InputHandler.DashdirectionInput;
                isGrounded = player.CheckIfGrounded();
                dashInputStop = player.InputHandler.DashInputStop;

                if (dashDirectionInput != Vector2.zero)
                { 
                    //방향이 0이 아니라면 dashDirectionInput을 대입하고 Normalize
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                Debug.Log(angle);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                //Dash를 누르고 maxHoldTime 시간이 초과하거나 Dash를 떼면 
                if (Time.unscaledTime >= startTime + playerData.maxHoldTime || dashInputStop)
                {
                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    player.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = playerData.drag;
                    player.SetVelocity(playerData.dashVelocity, dashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                }
            }
            else
            {
                player.SetVelocity(playerData.dashVelocity, dashDirection);

                if(Time.time >= startTime + playerData.dashTime)
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }
    //현재 Dash가 가능한지
    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    //땅에 닿으면 다시 Dash가 가능하게 만듬
    public void ResetCanDash() => CanDash = true;

    public void PlaceAfterImage()
    {
      
    }
}
