using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private readonly BasicEnemy basicEnemy;
    public EnemyAttackState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine,  string animBoolName) : base(basicEnemy, stateMachine,  animBoolName)
    {
        this.basicEnemy = basicEnemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    } 

    public override void Enter()
    {
        base.Enter();

        isAnimationFinished = false;
        basicEnemy.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public virtual void StartAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
