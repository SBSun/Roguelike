using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour, IDamageable
{
    [SerializeField] private D_HealthCondition healthData;
    public float CurrentHP { get; protected set; }

    protected virtual void Awake()
    {
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
        Debug.Log("데미지 입음");
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
