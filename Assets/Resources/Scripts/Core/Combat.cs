using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable
{
    public BoxCollider2D Collider { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        Collider = GetComponent<BoxCollider2D>();
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void Damage(WeaponAttackDetails details)
    {
        core.HealthCondition.DecreaseHP(details.damageAmount);

        if (core.HealthCondition.CurrentHP <= 0)
        {
            Death();
            return;
        }
    }

    public virtual void Death()
    {
        return;
    }

}
