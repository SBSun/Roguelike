using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    #region State º¯¼ö 
    public EnemyStateMachine StateMachine { get; private set; }
    
    #endregion

    protected SO_EnemyData EnemyData { get; private set; }

    public override void Awake()
    {
        base.Awake();

        EnemyData = (SO_EnemyData)EntityData;
        StateMachine = new EnemyStateMachine();
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
