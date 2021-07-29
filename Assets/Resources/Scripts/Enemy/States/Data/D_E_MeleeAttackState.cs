using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyMeleeAttackState Data", menuName = "Data/EnemyState Data/EnemyMeleeAttackState")]
public class D_E_MeleeAttackState : ScriptableObject
{
    [Header("MeleeAttack State")]
    [SerializeField] protected WeaponAttackDetails attackDetails;

    public WeaponAttackDetails AttackDetails { get => attackDetails; set => attackDetails = value; }
}
