using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    melee, //근거리
    range  //원거리
}

public class AggressiveEnemy : Enemy
{
    public AttackType attackType;


}
