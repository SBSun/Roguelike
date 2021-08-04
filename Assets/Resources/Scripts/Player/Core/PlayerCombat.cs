using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable, IKnockbackable
{
    private PlayerCore core;
    public bool isKnockbackActive { get; private set; }
    private float knockbackStartTime;


    public float CurrentHP { get; private set; }

    private void Awake()
    {
        core = GetComponentInParent<PlayerCore>();
        CurrentHP = core.player.GetMaxHp();
    }

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(WeaponAttackDetails details)
    {
        if (CurrentHP <= 0)
        {
            Death();
        }

        int attackDirection;

        if (details.attackPosition.x > transform.position.x)
            attackDirection = -1;
        else
            attackDirection = 1;

        Knockback(details.knockbackStrength, details.knockbackAngle, attackDirection);
        core.player.StateMachine.ChangeState(core.player.DamagedState);
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
