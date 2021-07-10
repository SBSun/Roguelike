using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal, //�Ϲ�
    Boss    //����
}

public enum AttackType
{
    None,   //���ݾ���
    Melee,  //��������
    Range,  //���Ÿ� ����
    Magic   //���� ����
}

public class D_Enemy : ScriptableObject
{
    public EnemyType enemyType;
    public AttackType attackType;

    [Header("Health Condition")]
    public float maxHP = 100f;
}
