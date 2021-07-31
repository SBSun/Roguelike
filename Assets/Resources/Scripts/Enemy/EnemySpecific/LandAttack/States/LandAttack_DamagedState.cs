using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_DamagedState : EnemyDamagedState
{
    private LandAttackEnemy landAttackEnemy;

    private bool isTouchingWallFront;
    private bool isCliffing;
    private bool isPlayerInAttackArea;

    public LandAttack_DamagedState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.landAttackEnemy = landAttackEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        landAttackEnemy.Movement.SetVelocity(damagedDetails.knockbackSpeed, damagedDetails.knockbackAngle, damagedDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isTouchingWallFront = landAttackEnemy.CollisionSense.WallFront;
        isCliffing = landAttackEnemy.CollisionSense.Cliffing;
        isPlayerInAttackArea = landAttackEnemy.CollisionSense.PlayerInAttackArea;

        if (Time.time >= startTime + damagedDetails.knockbackTime && !isKnockbackStop)
        {
            isKnockbackStop = true;
            landAttackEnemy.Movement.SetVelocityZero();
        }

        if (isStunTimeOver)
        {
            if (isTouchingWallFront || isCliffing || isPlayerInAttackArea)
                stateMachine.ChangeState(landAttackEnemy.PlayerLookForState);
            else
                stateMachine.ChangeState(landAttackEnemy.PlayerFollowState);
        }
    }

  
}
