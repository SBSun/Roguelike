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

        IdleState = new BasicIdleState(this, StateMachine, EnemyData, "idle");
        MoveState = new BasicMoveState(this, StateMachine, EnemyData, "move", CollisionSense);
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);

        CollisionSense = GetComponent<BasicEnemyCollisionSense>();
    }
}
