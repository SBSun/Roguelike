using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_AttackState : EnemyAttackState
{
    private LandMoveAttackEnemy landMoveAttackEnemy;
    private D_E_MeleeAttackState stateData;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    public LandAttack_AttackState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_MeleeAttackState stateData) : base(landMoveAttackEnemy, stateMachine, animBoolName)
    {
        this.landMoveAttackEnemy = landMoveAttackEnemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        landMoveAttackEnemy.Core.Movement.SetVelocityX(0f);
        landMoveAttackEnemy.Core.Movement.PlayerDirectionFlip(landMoveAttackEnemy.PlayerDirection);
        isAnimationFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isPlayerDetected = landMoveAttackEnemy.PlayerDetected;
        isPlayerInAttackArea = landMoveAttackEnemy.PlayerInAttackArea;
        landMoveAttackEnemy.Core.Movement.SetVelocityX(0f);

        if (isAnimationFinished)
        {
            landMoveAttackEnemy.EnemyHpBar.InactiveHpBar();
            stateMachine.ChangeState(landMoveAttackEnemy.IdleState);
        }
        else if (!isPlayerInAttackArea)
        {
            SetPlayerDamageable(null);
        }
    }

    public override void TriggerAttack()
    {
        if (playerDamageable != null)
        {
            WeaponAttackDetails attackDetails = stateData.AttackDetails;
            attackDetails.attackPosition = landMoveAttackEnemy.transform.position;

            playerDamageable.Damage(attackDetails);
        }
    }

    public bool CheckAttackCoolTime()
    {
        if (Time.time >= stateData.AttackDetails.attackCoolTime + lastAttackTime)
            return true;
        else
            return false;
    }
}
