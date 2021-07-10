using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public EnemyIdleState IdleState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }
    public EnemyPlayerDetectedState PlayerDetectedState { get; private set; }
    public BasicEnemyCollisionSense CollisionSense { get; private set; }
    public BasicEnemyMovement Movement { get; private set; }
    public BasicEnemyHealthCondition HealthCondition { get; private set; }
    public BoxCollider2D Collider { get; private set; }
 
    protected override void Awake()
    {
        base.Awake();
        Collider = GetComponent<BoxCollider2D>();
        CollisionSense = GetComponentInChildren<BasicEnemyCollisionSense>();
        Movement = GetComponentInChildren<BasicEnemyMovement>();
        HealthCondition = GetComponentInChildren<BasicEnemyHealthCondition>();
        IdleState = new EnemyIdleState(this, StateMachine, "idle");
        MoveState = new EnemyMoveState(this, StateMachine, "move");
        PlayerDetectedState = new EnemyPlayerDetectedState(this, StateMachine, "move");
    }

    protected override void Start()
    {
        base.Start();

        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        Movement.LogicUpdate();
    }
}
