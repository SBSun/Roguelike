using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_AttackState : EnemyAttackState
{
    private Goblin goblin;
    private D_E_MeleeAttackState stateData;

    private AttackInfoToEnemy attackInfo;

    protected bool isPlayerDetected;

    public Goblin_AttackState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName,  D_E_MeleeAttackState stateData, AttackInfoToEnemy attackInfo) : base(goblin, stateMachine, animBoolName)
    { 
        this.goblin = goblin;
        this.stateData = stateData;
        this.attackInfo = attackInfo;
    }

    public override void Enter()
    {
        base.Enter();


        goblin.Movement.SetVelocityX(0f);
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

        }
    }

    public override void TriggerAttack()
    {
        Collider2D playerCol = attackInfo.GetPlayerCol();

        if(playerCol != null)
        {
            IDamageable damageable = playerCol.GetComponent<IDamageable>();
            damageable.Damage(stateData.attackDamage);
        }
    }
}
