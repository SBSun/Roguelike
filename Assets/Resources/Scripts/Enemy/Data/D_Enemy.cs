using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal, //일반
    Boss    //보스
}

public enum AttackType
{
    None,   //공격안함
    Melee,  //근접공격
    Range,  //원거리 공격
    Magic   //마법 공격
}

public enum DamagedType
{
    Normal,     //일반(데미지 경직)
    SuperArmor  //경직 X
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
