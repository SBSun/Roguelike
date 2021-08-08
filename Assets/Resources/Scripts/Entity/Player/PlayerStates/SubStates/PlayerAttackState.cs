using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private int xInput;

    private float velocityToSet;
    private bool setVelocity;
    private bool shouldCheckFlip;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

        player.WeaponManager.CurrentWeapon.InitializeWeapon(this, player.Core);
        player.WeaponManager.CurrentWeapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();

        player.WeaponManager.CurrentWeapon.ExitWeapon();
    }

    public void SetPlayerVelocity(float velocity)
    {
        player.Core.Movement.SetVelocityX(velocity * player.Core.Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;

        if(shouldCheckFlip)
        {
            player.Core.Movement.CheckIfShouldFlip(xInput);
        }

        if(setVelocity)
        {
            player.Core.Movement.SetVelocityX(velocityToSet * player.Core.Movement.FacingDirection);
        }
    }
}
