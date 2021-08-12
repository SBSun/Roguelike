using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : Combat, IKnockbackable
{
    private EnemyCore core;

    public bool isKnockbackable { get; private set; }
    public float knockbackStartTime { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        core = GetComponentInParent<EnemyCore>();
    }

    public override void Damage(WeaponAttackDetails details)
    {
        base.Damage(details);
        core.Enemy.Damage();
        core.Enemy.EnemyHpBar.SetHp(CurrentHP, healthData.maxHP);
    }

    public override void Death()
    {
        base.Death();
        core.Enemy.Death();
    }

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Knockback(float strength, Vector2 angle, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        knockbackStartTime = Time.time;
        isKnockbackable = true;
    }

    public void CheckKnockback()
    {
        if(Time.time >= knockbackStartTime + damagedDetails.knockbackTime && isKnockbackable)
        {
            core.Movement.CanSetVelocity = true;
            core.Movement.SetVelocityZero();

            if(core.CollisionSense.Grounded && core.Movement.CurrentVelocity.y < 0.01f && Time.time >= knockbackStartTime + damagedDetails.stunTime)
                isKnockbackable = false;
        }
    }
}
