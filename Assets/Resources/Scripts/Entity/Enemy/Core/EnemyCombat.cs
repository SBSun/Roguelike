using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : Combat, IKnockbackable
{
    private EnemyCore core;

    public float knockbackStartTime { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        core = GetComponentInParent<EnemyCore>();
    }

    public override void Damage(WeaponAttackDetails details)
    {
        base.Damage(details);
        core.Enemy.OnDamage();
    }

    public void LogicUpdate()
    {

    }

    public void Knockback(float strength, Vector2 angle, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        knockbackStartTime = Time.time;
    }
}
