using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_AttackState : EnemyAttackState
{
    private Goblin goblin;
    private D_E_MeleeAttackState stateData;

    protected bool isPlayerDetected;

    public Goblin_AttackState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_MeleeAttackState stateData ) : base(goblin, stateMachine, animBoolName)
    { 
        this.goblin = goblin;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        goblin.Movement.SetVelocityX(0f);
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

        if(isAnimationFinished)
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
    }

    public override void TriggerAttack()
    {
        if(playerDamageable != null)
        {
            playerDamageable.Damage(stateData.attackDamage);
            Debug.Log("player���� " + stateData.attackDamage + "���ظ� ��");
        }
    }
}
