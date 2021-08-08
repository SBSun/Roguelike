using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_PlayerLookForState : LandAttack_PlayerDiscoverState
{
    public LandAttack_PlayerLookForState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(landAttackEnemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        landAttackEnemy.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            stateMachine.ChangeState(landAttackEnemy.PlayerFollowState);

        landAttackEnemy.Movement.SetVelocityZero();
    }
}
