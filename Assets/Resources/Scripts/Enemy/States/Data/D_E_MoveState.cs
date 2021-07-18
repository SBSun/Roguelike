using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyMoveState Data", menuName = "Data/EnemyState Data/EnemyMoveState")]
public class D_E_MoveState : ScriptableObject
{
    [Header("Move State")]
    public float minMoveTime = 1f;
    public float maxMoveTime = 4f;
    public float movementVelocity = 8f;
}
