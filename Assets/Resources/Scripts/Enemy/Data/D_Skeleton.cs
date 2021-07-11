using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "D_Skeleton", menuName = "Data/Enemy/Skeleton Data")]
public class D_Skeleton : D_Enemy
{
    [Header("Idle State")]
    public float minIdleTime = 2f;
    public float maxIdleTime = 5f;

    [Header("Move State")]
    public float minMoveTime = 2f;
    public float maxMoveTime = 5f;
    public float movementVelocity = 4f;
}
