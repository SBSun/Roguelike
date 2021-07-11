using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "D_Goblin", menuName = "Data/Enemy/Goblin Data")]
public class D_Goblin : D_Enemy
{
    [Header("Idle State")]
    public float minIdleTime = 1f;
    public float maxIdleTime = 4f;

    [Header("Move State")]
    public float minMoveTime = 1f;
    public float maxMoveTime = 4f;
    public float movementVelocity = 8f;
}
