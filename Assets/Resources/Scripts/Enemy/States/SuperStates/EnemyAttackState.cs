using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected IDamageable playerDamageable;
    public AttackInfoToEnemy attackInfo { get; private set; }
    protected bool isAnimationFinished;
    protected float attackTime;


    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        this.attackInfo = attackInfo;
    }

    public override void Enter()
    {
        base.Enter();

        isAnimationFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }

    public void SetPlayerDamageable(IDamageable damageable)
    {
        playerDamageable = damageable;
    }
}
