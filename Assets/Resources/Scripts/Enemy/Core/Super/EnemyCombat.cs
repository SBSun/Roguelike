using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    private Enemy enemy;

    public float CurrentHP { get; private set; }

    private void Awake()
    {
        CurrentHP = enemy.GetMaxHp();
    }

    public void Damage(WeaponAttackDetails details)
    {
        
    }

    public void Death()
    {
        
    }
}
