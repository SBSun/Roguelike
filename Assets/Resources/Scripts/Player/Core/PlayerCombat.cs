using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable, IKnockbackable
{
    private PlayerCore core;

    private void Awake()
    {
        core = GetComponentInParent<PlayerCore>();
    }

    public void Damage(WeaponAttackDetails weaponAttackDetails)
    {

    }

    public void Death()
    {

    }

    public void Knockback(float strength, Vector2 angle, int direction)
    {

    }
}
