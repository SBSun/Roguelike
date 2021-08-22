using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponAttackDetails
{
    [Header("�����ϸ鼭 �����̴� �ӵ�")]
    public float movementSpeed;
    [Header("������ ������")]
    public float damageAmount;
    [Header("���� ���� �ð�")]
    public float stunTime;
    [Header("������ ��Ÿ��")]
    public float attackCoolTime;
    [Header("Knockback ���ӽð�")]
    public float knockbackTime;
    [Header("Knockback ��")]
    public float knockbackStrength;
    [Header("Knockback ����")]
    public Vector2 knockbackAngle;
    [HideInInspector]
    public Vector2 attackPosition;
}