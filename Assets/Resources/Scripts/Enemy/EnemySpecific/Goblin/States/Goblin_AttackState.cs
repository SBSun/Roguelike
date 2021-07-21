using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_AttackState : EnemyAttackState
{
    private Goblin goblin;
    private D_E_MeleeAttackState stateData;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    public Goblin_AttackState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_MeleeAttackState stateData ) : base(goblin, stateMachine, animBoolName)
    { 
        this.goblin = goblin;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        goblin.Movement.SetVelocityX(0f);
        goblin.Movement.PlayerDirectionFlip(goblin.CollisionSense.PlayerDirection);
        isAnimationFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if (isAnimationFinished)
        {
            Debug.Log("attack finish");
            stateMachine.ChangeState(goblin.IdleState);
        }
        else if(!isPlayerInAttackArea)
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
