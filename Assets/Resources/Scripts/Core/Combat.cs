using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    public float CurrentHP { get; protected set; }

    public bool isKnockbackActive { get; private set; }
    private float knockbackStartTime;

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(WeaponAttackDetails details)
    {
        if(CurrentHP - details.damageAmount <= 0)
        {
            Death();
            return;
        }
    }

    public void Death()
    {

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
