using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyIdleState Data", menuName = "Data/EnemyState Data/EnemyIdleState")]
public class D_E_IdleState : ScriptableObject
{
    [Header("Idle State")]
    public float minIdleTime = 1f;
    public float maxIdleTime = 4f;
}
