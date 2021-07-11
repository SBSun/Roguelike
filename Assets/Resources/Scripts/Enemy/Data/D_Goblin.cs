using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Goblin Data", menuName = "Data/Enemy/Goblin Data")]
public class D_Goblin : D_Enemy
{
    [Header("Idle State")]
    public float minIdleTime = 2f;
    public float maxIdleTime = 5f;

    [Header("Move State")]
    public float minMoveTime = 2f;
    public float maxMoveTime = 5f;
    public float movementVelocity = 8f;
}
