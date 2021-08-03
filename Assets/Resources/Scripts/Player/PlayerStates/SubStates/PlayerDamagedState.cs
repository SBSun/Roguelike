using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerAbilityState
{
    private bool isKnockbackStop;

    private WeaponAttackDetails damagedDetails; //맞은 공격의 정보
    private int damagedDirection;

    public PlayerDamagedState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        isKnockbackStop = false;
        player.Movement.SetVelocity(damagedDetails.knockbackStrength, damagedDetails.knockbackAngle, damagedDirection);
        player.SpriteFlash.OnFlash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + damagedDetails.knockbackTime && !isKnockbackStop)
        {
            isKnockbackStop = true;
            player.Movement.SetVelocityZero();
            player.SpriteFlash.OffFlash();
        }
        if (Time.time >= startTime + damagedDetails.stunTime)
            isAbilityDone = true;
    }


    public void SetDamagedAttackDetails(WeaponAttackDetails attackDetails, int attackDirection)
    {
        damagedDetails = attackDetails;
        damagedDirection = attackDirection;
    }
}
