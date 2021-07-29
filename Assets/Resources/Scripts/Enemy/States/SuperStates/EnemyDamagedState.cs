using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : EnemyState
{
    protected D_E_DamagedState stateData;
    protected bool isStunTimeOver;
    protected bool isKnockbackStop;

    protected WeaponAttackDetails damagedDetails; //맞은 공격의 정보
    protected int damagedDirection;

    public EnemyDamagedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
        isKnockbackStop = false;
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

    public void SetDamagedAttackDetails(WeaponAttackDetails attackDetails, int attackDirection)
    {
        damagedDetails = attackDetails;
        damagedDirection = attackDirection;
    }
}
