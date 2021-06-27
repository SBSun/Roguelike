using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new SO_EnemyData", menuName = "Data/Enemy Data/Base Data")]
public class SO_EnemyData : SO_EntityData
{
    [Header("Idle State")]
    public float minIdleTime = 3f;
    public float maxIdleTime = 7f;

    [Header("Move State")]
    public float movementVelocity = 8f;
}
