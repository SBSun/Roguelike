using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyDamagedState Data", menuName = "Data/EnemyState Data/EnemyDamagedState")]
public class D_E_DamagedState : ScriptableObject
{
    [Header("Damaged State")]
    public float stunTime = 0.5f;
    public float stunKnockbackTime = 0.2f;
    public float stunKnockbackSpeed = 20f;
    public float stunKnockbackAngle; 
}
