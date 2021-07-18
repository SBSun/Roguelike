using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyMeleeAttackState Data", menuName = "Data/EnemyState Data/EnemyMeleeAttackState")]
public class D_E_MeleeAttackState : ScriptableObject
{
    [Header("MeleeAttack State")]
    public float attackDamage = 10f;
    public float attackCoolTime = 1f;
}
