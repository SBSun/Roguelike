using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    melee, //�ٰŸ�
    range  //���Ÿ�
}

public class AggressiveEnemy : Enemy
{
    public AttackType attackType;


}
