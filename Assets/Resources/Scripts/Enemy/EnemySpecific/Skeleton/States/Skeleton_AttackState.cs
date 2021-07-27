using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_AttackState : EnemyAttackState
{
    protected Skeleton skeleton;
    private D_E_MeleeAttackState stateData;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    public Skeleton_AttackState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName, D_E_MeleeAttackState stateData) : base(skeleton, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        skeleton.Movement.SetVelocityX(0f);
        skeleton.Movement.PlayerDirectionFlip(skeleton.CollisionSense.PlayerDirection);
        isAnimationFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isPlayerDetected = skeleton.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = skeleton.CollisionSense.PlayerInAttackArea;

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(skeleton.IdleState);
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
            playerDamageable.Damage(stateData.attackDamage);
        }
    }

    public bool CheckAttackCoolTime()
    {
        if (Time.time >= stateData.attackCoolTime + lastAttackTime)
            return true;
        else
            return false;
    }
}
