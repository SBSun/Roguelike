using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour, IDamageable
{
    public float CurrentHP { get; protected set; }

    public virtual void Damage(WeaponAttackDetails details)
    {
        if (CurrentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }
}
