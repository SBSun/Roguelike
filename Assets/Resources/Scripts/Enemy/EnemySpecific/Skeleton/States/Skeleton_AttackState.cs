using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_AttackState : EnemyState
{
    protected Skeleton skeleton;

    public Skeleton_AttackState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName) : base(skeleton, stateMachine, animBoolName)
    {
    }
}
