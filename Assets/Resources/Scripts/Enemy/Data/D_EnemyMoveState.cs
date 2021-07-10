using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_EnemyMoveState : ScriptableObject
{
    [Header("Move State")]
    public float minMoveTime = 2f;
    public float maxMoveTime = 5f;

    public float movementVelocity = 8f;
}
