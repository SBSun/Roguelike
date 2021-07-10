using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : EnemyAttackState
{
    public MeleeAttackState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine, string animBoolName) : base(basicEnemy, stateMachine,  animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void StartAttack()
    {
        base.StartAttack();
    }

    public void CheckMeleeAttack(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            //damageable.Damage();
        }
    }
}
