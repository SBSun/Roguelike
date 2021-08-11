using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Combat : MonoBehaviour, IDamageable
{
    public BoxCollider2D Collider { get; private set; }
    [SerializeField] private D_HealthCondition healthData;
    public float CurrentHP { get; protected set; }

    protected virtual void Awake()
    {
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

    
}
