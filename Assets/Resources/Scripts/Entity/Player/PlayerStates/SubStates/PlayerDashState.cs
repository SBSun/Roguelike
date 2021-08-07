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
    private Vector2 lastAfterSpritePos;

    private bool isGrounded;
    private bool dashInputStop;
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        //Dash ���ϰ� ����
        CanDash = false;
        player.InputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * player.Movement.FacingDirection;

        //�������� ��
        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime; //timeScale ������ ���� ����

        //ȭ��ǥ �̹��� Ȱ��ȭ
        player.DashDirectionIndicator.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        player.Movement.SetVelocityY(0f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.Anim.SetFloat("yVelocity", player.Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.Movement.CurrentVelocity.x));

            //Dash�� ���� ���¿��� maxHoldTime �ð��� �ʰ��ϰų� Dash�� ���� �뽬 Ű�� ������ 
            if (isHolding)
            {
                isGrounded =player.CollisionSense.Grounded;

                if (isGrounded)
                {
                    Debug.Log("DashCancle");
                    DashCancle();
                }

                //���� ����
                dashDirectionInput = player.InputHandler.DashdirectionInput;
 
                dashInputStop = player.InputHandler.DashInputStop;

                if (dashDirectionInput != Vector2.zero)
                { 
                    //������ 0�� �ƴ϶�� dashDirectionInput�� �����ϰ� Normalize
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);

                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                //Dash�� ���� ���¿��� maxHoldTime �ð��� �ʰ��ϰų� Dash�� ���� 
                if (Time.unscaledTime >= startTime + playerData.maxHoldTime || dashInputStop)
                {
                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    player.Movement.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = playerData.drag;
                    player.Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterSprite();
                }
            }
            else
            {
                player.Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                CheckIfShouldPlaceAfterSprite();

                if(Time.time >= startTime + playerData.dashTime)
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }
    //���� Dash�� ��������
    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    //���� ������ �ٽ� Dash�� �����ϰ� ����
    public void ResetCanDash() => CanDash = true;

    public void DashCancle()
    {
        isHolding = false;
        Time.timeScale = 1f;
        player.RB.drag = 0f;
        isAbilityDone = true;
        lastDashTime = Time.time;
        player.DashDirectionIndicator.gameObject.SetActive(false);
    }

    private void CheckIfShouldPlaceAfterSprite()
    {
        if(Vector2.Distance(player.transform.position, lastAfterSpritePos) >= playerData.distBetweenAfterSprites)
        {
            PlaceAfterSprite();
        }
    }

    private void PlaceAfterSprite()
    {
        PlayerAfterSpritePool.Instance.GetFromPool();
        lastAfterSpritePos = player.transform.position;
    }
}
