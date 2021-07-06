using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public BasicIdleState IdleState { get; private set; }
    public BasicMoveState MoveState { get; private set; }
    public BasicPlayerDetectedState PlayerDetectedState { get; private set; }
    public BasicEnemyCollisionSense CollisionSense { get; private set; }
    public BoxCollider2D Collider;
 
    protected override void Awake()
    {
        base.Awake();
        Collider = GetComponent<BoxCollider2D>();
        CollisionSense = GetComponent<BasicEnemyCollisionSense>();
        IdleState = new BasicIdleState(this, StateMachine, EnemyData, "idle");
        MoveState = new BasicMoveState(this, StateMachine, EnemyData, "move");
        PlayerDetectedState = new BasicPlayerDetectedState(this, StateMachine, EnemyData, "playerDetected");
    }

    protected override void Start()
    { 
        StateMachine.Initialize(IdleState);
    }


}
