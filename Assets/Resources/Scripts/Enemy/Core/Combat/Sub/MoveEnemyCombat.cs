using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCombat : Combat, IKnockbackable
{
    private LandEnemyMovement movement;

    public bool isKnockbackActive { get; private set; }
    private float knockbackStartTime;

    private void Awake()
    {
        movement = transform.parent.GetComponentInChildren<LandEnemyMovement>();
    }

    public override void Damage(WeaponAttackDetails details)
    {
        base.Damage(details);

        int attackDirection;

        if (details.attackPosition.x > transform.position.x)
            attackDirection = -1;
        else
            attackDirection = 1;

        Knockback(details.knockbackStrength, details.knockbackAngle, attackDirection);
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
