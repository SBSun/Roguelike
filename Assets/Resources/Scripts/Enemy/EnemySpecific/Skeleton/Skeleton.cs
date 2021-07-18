using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton_IdleState IdleState { get; private set; }
    public Skeleton_MoveState MoveState { get; private set; }
    public Skeleton_PlayerDetectedState PlayerDetectedState { get; private set; }

    [SerializeField] private D_E_IdleState D_IdleState;
    [SerializeField] private D_E_MoveState D_MoveState;

    public BasicLandEnemyMovement Movement { get; private set; }
    public BasicLandEnemyCollisionSense CollisionSense { get; private set; }

    [SerializeField] private D_Enemy D_Skeleton;

    protected override void Awake()
    {
        base.Awake();



        IdleState = new Skeleton_IdleState(this, StateMachine, "idle", D_IdleState);
        MoveState = new Skeleton_MoveState(this, StateMachine, "move", D_MoveState);
        PlayerDetectedState = new Skeleton_PlayerDetectedState(this, StateMachine, "move");

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
