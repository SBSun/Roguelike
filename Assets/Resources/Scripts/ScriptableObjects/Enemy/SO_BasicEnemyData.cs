using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new SO_BasicEnemyData", menuName = "Data/BasicEnemy Data/Base Data")]
public class SO_BasicEnemyData : SO_EnemyData
{
    [Header("Idle State")]
    public float minIdleTime = 2f;
    public float maxIdleTime = 5f;

    [Header("Move State")]
    public float minMoveTime = 2f;
    public float maxMoveTime = 5f;

    [Header("Move State")]
    public float movementVelocity = 8f;
}
