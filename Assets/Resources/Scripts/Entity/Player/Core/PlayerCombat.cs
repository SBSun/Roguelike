using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat, IKnockbackable
{
    private PlayerCore core;

    public bool isKnockbackable { get; private set; }
    public float knockbackStartTime { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        core = GetComponentInParent<PlayerCore>();
        isKnockbackable = false;
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
        isKnockbackable = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (Time.time >= knockbackStartTime + damagedDetails.knockbackTime && isKnockbackable)
        {
            core.Movement.CanSetVelocity = true;
            core.Movement.SetVelocityZero();
            core.Player.SpriteFlash.OffFlash();

            if (core.CollisionSense.Grounded && core.Movement.CurrentVelocity.y < 0.01f && Time.time >= knockbackStartTime + damagedDetails.stunTime)
                isKnockbackable = false;
        }
    }

}
