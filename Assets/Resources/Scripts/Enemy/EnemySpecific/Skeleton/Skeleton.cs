using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton_IdleState IdleState { get; private set; }
    public Skeleton_MoveState MoveState { get; private set; }
    public Skeleton_PlayerDetectedState PlayerDetectedState { get; private set; }

    public BasicLandEnemyMovement Movement { get; private set; }
    public BasicLandEnemyCollisionSense CollisionSense { get; private set; }

    private D_Skeleton skeletonData;

    protected override void Awake()
    {
        base.Awake();

        skeletonData = (D_Skeleton)enemyData;

        IdleState = new Skeleton_IdleState(this, StateMachine, "idle", skeletonData);
        MoveState = new Skeleton_MoveState(this, StateMachine, "move", skeletonData);
        PlayerDetectedState = new Skeleton_PlayerDetectedState(this, StateMachine, "move", skeletonData);

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
