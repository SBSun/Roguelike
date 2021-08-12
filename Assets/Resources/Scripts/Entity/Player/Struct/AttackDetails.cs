using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponAttackDetails
{
    [Header("공격하면서 움직이는 속도")]
    public float movementSpeed;
    [Header("공격의 데미지")]
    public float damageAmount;
    [Header("공격 기절 시간")]
    public float stunTime;
    [Header("공격의 쿨타임")]
    public float attackCoolTime;
    [Header("Knockback 지속시간")]
    public float knockbackTime;
    [Header("Knockback 힘")]
    public float knockbackStrength;
    [Header("Knockback 각도")]
    public Vector2 knockbackAngle;
    [HideInInspector]
    public Vector2 attackPosition;
}