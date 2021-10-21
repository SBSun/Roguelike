using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_DamagedState : EnemyDamagedState
{
    private LandMoveAttackEnemy landAttackEnemy;

    private bool isTouchingWallFront;
    private bool isCliffing;
    private bool isPlayerInAttackArea;

    public LandAttack_DamagedState(LandMoveAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.landAttackEnemy = landAttackEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = landAttackEnemy.Core.CollisionSense.WallFront;
        isCliffing = landAttackEnemy.Core.CollisionSense.Cliffing;
        isPlayerInAttackArea = landAttackEnemy.Core.CollisionSense.PlayerInAttackArea;

        if (!enemy.Core.Combat.isKnockbackable)
        {
            if (isTouchingWallFront || isCliffing || isPlayerInAttackArea)
                stateMachine.ChangeState(landAttackEnemy.PlayerLookForState);
            else
                stateMachine.ChangeState(landAttackEnemy.PlayerFollowState);
        }
    }

  
}
