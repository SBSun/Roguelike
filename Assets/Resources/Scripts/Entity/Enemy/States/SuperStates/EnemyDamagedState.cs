using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : EnemyState
{
    protected bool isKnockbackTimeOver;
    protected bool isGrounded;

    protected WeaponAttackDetails damagedDetails; //맞은 공격의 정보

    public EnemyDamagedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = enemy.Core.CollisionSense.Grounded;
    }

    public override void Enter()
    {
        base.Enter();
        isKnockbackTimeOver = false;
        enemy.SpriteFlash.OnFlash();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SpriteFlash.OffFlash();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isGrounded && enemy.Core.Movement.CurrentVelocity.y < 0.01f && Time.time >= enemy.Core.Combat.knockbackStartTime + damagedDetails.knockbackTime && !isKnockbackTimeOver)
        {
            isKnockbackTimeOver = true;
            enemy.Core.Movement.SetVelocityZero();
        }
    }
}
