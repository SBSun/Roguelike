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

public enum DamagedType
{
    Normal,     //�Ϲ�(������ ����)
    SuperArmor  //���� X
}

[CreateAssetMenu(fileName = "new D_Enemy", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    public EnemyType enemyType;
    public AttackType attackType;
    public DamagedType damagedType;

    [Header("Health Condition")]
    public float maxHP = 100f;
}
