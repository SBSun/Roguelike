using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCombat : Combat, IKnockbackable
{
    public bool isKnockbackActive { get; private set; }
    private float knockbackStartTime;

    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public override void Damage(WeaponAttackDetails details)
    {
        base.Damage(details);

       // core.player.StateMachine.ChangeState(core.player.DamagedState);
    }

    public override void Death()
    {
        base.Death();

    }

    public void Knockback(float strength, Vector2 angle, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Grounded)
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }

}
