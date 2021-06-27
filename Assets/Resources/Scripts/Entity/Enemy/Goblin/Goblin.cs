using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    #region State º¯¼ö
    public Goblin_IdleState IdleState { get; private set; }
    public Goblin_MoveState MoveState { get; private set; }
    #endregion
    public override void Awake()
    {
        base.Awake();

        IdleState = new Goblin_IdleState(this, StateMachine, EnemyData, "idle");
        MoveState = new Goblin_MoveState(this, StateMachine, EnemyData, "move");
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();
    }
}
