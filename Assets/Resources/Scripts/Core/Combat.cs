using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    public BoxCollider2D Collider { get; protected set; }

    public D_HealthCondition healthData { get; private set; }
    public float CurrentHP { get; protected set; }

    public bool isKnockbackActive { get; private set; }
    private float knockbackStartTime;

    protected override void Awake()
    {
        base.Awake();

        Collider = GetComponent<BoxCollider2D>();
        CurrentHP = healthData.maxHP;
    }

    public void IncreaseHP(float increase)
    {
        if (CurrentHP + increase >= healthData.maxHP)
            CurrentHP = healthData.maxHP;
        else
            CurrentHP += increase;
    }

    public void DecreaseHP(float decrease)
    {
        if (CurrentHP - decrease <= 0)
            CurrentHP = 0;
        else
            CurrentHP -= decrease;
    }

    public virtual void LogicUpdate()
    {
        CheckKnockback();
    }

    public virtual void Damage(WeaponAttackDetails details)
    {
        DecreaseHP(details.damageAmount);

        if (CurrentHP <= 0)
        {
            Death();
            return;
        }
    }

    public virtual void Death()
    {
        return;
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
