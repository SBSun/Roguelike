using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_PlayerLookForState : LandAttack_PlayerDiscoverState
{
    public LandAttack_PlayerLookForState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(landMoveAttackEnemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        landMoveAttackEnemy.Core.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isTouchingWallFront && !isCliffing && !isPlayerInAttackArea)
            stateMachine.ChangeState(landMoveAttackEnemy.PlayerFollowState);

        landMoveAttackEnemy.Core.Movement.SetVelocityZero();
    }
}
