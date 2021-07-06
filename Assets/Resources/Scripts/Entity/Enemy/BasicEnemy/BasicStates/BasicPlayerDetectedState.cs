using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerDetectedState : EnemyState
{
    private readonly BasicEnemy basicEnemy;
    private readonly SO_BasicEnemyData basicEnemyData;

    public BasicPlayerDetectedState(BasicEnemy basicEnemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName) : base(basicEnemy, stateMachine, enemyData, animBoolName)
    { 
        this.basicEnemy = basicEnemy;
        basicEnemyData = (SO_BasicEnemyData) enemyData;
}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }
}
