using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    public Goblin_IdleState IdleState { get; private set; }
    public Goblin_MoveState MoveState { get; private set; }
    public Goblin_PlayerDetectedState PlayerDetectedState { get; private set; }

    public BasicLandEnemyMovement Movement { get; private set; }
    public BasicLandEnemyCollisionSense CollisionSense { get; private set; }

    private D_Goblin goblinData;

    protected override void Awake()
    {
        base.Awake();

        goblinData = (D_Goblin)enemyData;

        IdleState = new Goblin_IdleState(this, StateMachine, "idle", goblinData);
        MoveState = new Goblin_MoveState(this, StateMachine, "move", goblinData);
        PlayerDetectedState = new Goblin_PlayerDetectedState(this, StateMachine, "move", goblinData);

        Movement = GetComponentInChildren<BasicLandEnemyMovement>();
        CollisionSense = GetComponentInChildren<BasicLandEnemyCollisionSense>();
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
