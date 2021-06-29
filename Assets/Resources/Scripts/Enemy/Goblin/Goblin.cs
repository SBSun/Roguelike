using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    #region State º¯¼ö
    public Goblin_IdleState IdleState { get; private set; }
    public Goblin_MoveState MoveState { get; private set; }
    public Goblin_CollisionSense CollisionSense { get; private set; }


    #endregion
    protected override void Awake()
    {
        base.Awake();

        IdleState = new Goblin_IdleState(this, StateMachine, EnemyData, "idle");
        MoveState = new Goblin_MoveState(this, StateMachine, EnemyData, "move");
    }

    protected override void Start()
    {
        CollisionSense = GetComponent<Goblin_CollisionSense>();

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
