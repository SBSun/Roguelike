using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : EnemyState
{
    protected D_E_DamagedState stateData;
    protected bool isStunTimeOver;

    public EnemyDamagedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_E_DamagedState stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
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

        if (Time.time >= startTime + stateData.stunTime)
            isStunTimeOver = true;
    }
}
