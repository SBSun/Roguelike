using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerAbilityState
{
    public PlayerDamagedState(Player player, PlayerStateMachine stateMachine, D_Player playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.SpriteFlash.OnFlash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!player.Core.Combat.isKnockbackActive)
        {
            player.SpriteFlash.OffFlash();
            isAbilityDone = true;
        }
    }
}
