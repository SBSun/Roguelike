using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_EnemyIdleState : ScriptableObject
{
    [Header("Idle State")]
    public float minIdleTime = 2f;
    public float maxIdleTime = 5f;
}
