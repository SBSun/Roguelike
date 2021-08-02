using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_AttackState : EnemyAttackState
{
    private LandAttackEnemy landAttackEnemy;
    private D_E_MeleeAttackState stateData;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    public LandAttack_AttackState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_MeleeAttackState stateData) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.landAttackEnemy = landAttackEnemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        landAttackEnemy.Movement.SetVelocityX(0f);
        landAttackEnemy.Movement.PlayerDirectionFlip(landAttackEnemy.CollisionSense.PlayerDirection);
        isAnimationFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isPlayerDetected = landAttackEnemy.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = landAttackEnemy.CollisionSense.PlayerInAttackArea;

        if (isAnimationFinished)
        {
            landAttackEnemy.EnemyHpBar.InactiveHpBar();
            stateMachine.ChangeState(landAttackEnemy.IdleState);
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
            attackDetails.attackPosition = landAttackEnemy.transform.position;

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
