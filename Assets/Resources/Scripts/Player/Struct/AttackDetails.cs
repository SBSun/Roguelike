using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponAttackDetails
{
    public float movementSpeed;
    public float damageAmount;
    public float attackCoolTime;
    public float stunTime;
    public float knockbackTime;
    public float knockbackSpeed;
    public Vector2 knockbackAngle;
    public Vector2 attackPosition;
}