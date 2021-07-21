using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    public Goblin_IdleState IdleState { get; private set; }
    public Goblin_MoveState MoveState { get; private set; }
    public Goblin_PlayerDetectedState PlayerDetectedState { get; private set; }
    public Goblin_AttackState AttackState { get; private set; }

    [SerializeField] private D_E_IdleState idleStateData;
    [SerializeField] private D_E_MoveState moveStateData;
    [SerializeField] private D_E_MeleeAttackState meleeAttackStateData;

    public BasicLandEnemyMovement Movement { get; private set; }
    public BasicLandEnemyCollisionSense CollisionSense { get; private set; }

    public AttackInfoToEnemy AttackInfo { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        AttackInfo = GetComponent<AttackInfoToEnemy>();
        Movement = GetComponentInChildren<BasicLandEnemyMovement>();
        CollisionSense = GetComponentInChildren<BasicLandEnemyCollisionSense>();

        IdleState = new Goblin_IdleState(this, StateMachine, "idle", idleStateData);
        MoveState = new Goblin_MoveState(this, StateMachine, "move", moveStateData);
        PlayerDetectedState = new Goblin_PlayerDetectedState(this, StateMachine, "idle", moveStateData);
        AttackState = new Goblin_AttackState(this, StateMachine, "attack",meleeAttackStateData);
    }

    protected override void Start()
    {
        base.Start();

        AttackInfo.AttackState = AttackState;
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        Movement.LogicUpdate();
    }
}
