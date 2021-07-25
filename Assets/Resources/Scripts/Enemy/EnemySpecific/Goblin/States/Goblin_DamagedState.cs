using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_DamagedState : EnemyState
{
    protected D_E_DamagedState stateData;

    protected float stunTime = 0.3f;
    protected bool isStunTimeOver;

    public Goblin_DamagedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_E_DamagedState stateData) : base(enemy, stateMachine, animBoolName)
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

        if (Time.time >= startTime + stunTime)
            isStunTimeOver = true;
    }
}
