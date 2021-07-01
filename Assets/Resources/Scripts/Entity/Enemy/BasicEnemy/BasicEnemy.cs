using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public BasicIdleState IdleState { get; private set; }
    public BasicMoveState MoveState { get; private set; }
    public BasicEnemyCollisionSense CollisionSense { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        CollisionSense = GetComponent<BasicEnemyCollisionSense>();
        IdleState = new BasicIdleState(this, StateMachine, EnemyData, "idle");
        MoveState = new BasicMoveState(this, StateMachine, EnemyData, "move", CollisionSense);
    }

    protected override void Start()
    { 
        StateMachine.Initialize(IdleState);
    }
}
