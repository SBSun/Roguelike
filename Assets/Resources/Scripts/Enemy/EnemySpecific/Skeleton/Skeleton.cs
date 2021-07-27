using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton_IdleState IdleState { get; private set; }
    public Skeleton_MoveState MoveState { get; private set; }
    public Skeleton_PlayerLookForState PlayerLookForState { get; private set; }
    public Skeleton_PlayerFollowState PlayerFollowState { get; private set; }
    public Skeleton_AttackState AttackState { get; private set; }
    public Skeleton_DamagedState DamagedState { get; private set; }

    [SerializeField] private D_E_IdleState idleStateData;
    [SerializeField] private D_E_MoveState moveStateData;
    [SerializeField] private D_E_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_E_DamagedState damagedStateData;

    public BasicLandEnemyMovement Movement { get; private set; }
    public BasicLandEnemyCollisionSense CollisionSense { get; private set; }

    public AttackInfoToEnemy AttackInfo { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        AttackInfo = GetComponent<AttackInfoToEnemy>();
        Movement = GetComponentInChildren<BasicLandEnemyMovement>();
        CollisionSense = GetComponentInChildren<BasicLandEnemyCollisionSense>();

        IdleState = new Skeleton_IdleState(this, StateMachine, "idle", idleStateData);
        MoveState = new Skeleton_MoveState(this, StateMachine, "move", moveStateData);
        PlayerLookForState = new Skeleton_PlayerLookForState(this, StateMachine, "playerLookFor");
        PlayerFollowState = new Skeleton_PlayerFollowState(this, StateMachine, "playerFollow", moveStateData); ;
        AttackState = new Skeleton_AttackState(this, StateMachine, "attack", meleeAttackStateData);
        DamagedState = new Skeleton_DamagedState(this, StateMachine, "damaged", damagedStateData);
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

    public override void Damage(float amount)
    {
        base.Damage(amount);

        if (StateMachine.CurrentState != DamagedState)
        {

            StateMachine.ChangeState(DamagedState);
        }

    }

    public override void Death()
    {
        base.Death();


    }
}
