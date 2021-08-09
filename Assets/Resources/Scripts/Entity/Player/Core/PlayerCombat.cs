using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat, IKnockbackable
{
    private PlayerCore core;

    public bool isKnockbackActive { get; private set; }
    private float knockbackStartTime;

    protected override void Awake()
    {
        base.Awake();
        core = GetComponentInParent<PlayerCore>();
    }

    public override void Damage(WeaponAttackDetails details)
    {
        base.Damage(details);
        core.Player.OnDamage();
    }

    public void LogicUpdate()
    {
        CheckKnockback();
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
        if (isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSense.Grounded)
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }

}
