using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : EnemyState
{
    protected bool isStunTimeOver;

    protected WeaponAttackDetails damagedDetails; //맞은 공격의 정보

    public EnemyDamagedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + damagedDetails.stunTime)
            isStunTimeOver = true;
    }

    public void StunTimeOver()
    {
        isStunTimeOver = true;
    }
}
