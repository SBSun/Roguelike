using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_AttackState : EnemyState
{
    protected Skeleton skeleton;
    protected D_Skeleton enemyData;
    public Skeleton_AttackState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName, D_Enemy enemyData) : base(skeleton, stateMachine, animBoolName, enemyData)
    {
    }
}
