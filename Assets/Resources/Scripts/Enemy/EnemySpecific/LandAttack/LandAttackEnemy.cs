using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttackEnemy : Enemy
{
    public LandAttack_IdleState IdleState { get; private set; }
    public LandAttack_MoveState MoveState { get; private set; }
    public LandAttack_PlayerLookForState PlayerLookForState { get; private set; }
    public LandAttack_PlayerFollowState PlayerFollowState { get; private set; }
    public LandAttack_AttackState AttackState { get; private set; }
    public LandAttack_DamagedState DamagedState { get; private set; }

    [SerializeField] private D_E_IdleState idleStateData;
    [SerializeField] private D_E_MoveState moveStateData;
    [SerializeField] private D_E_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_E_DamagedState damagedStateData;

    public LandAttack_Movement Movement { get; private set; }
    public LandAttack_CollisionSense CollisionSense { get; private set; }

    public AttackInfoToEnemy AttackInfo { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        AttackInfo = GetComponent<AttackInfoToEnemy>();
        Movement = GetComponentInChildren<LandAttack_Movement>();
        CollisionSense = GetComponentInChildren<LandAttack_CollisionSense>();

        IdleState = new LandAttack_IdleState(this, StateMachine, "idle", idleStateData);
        MoveState = new LandAttack_MoveState(this, StateMachine, "move", moveStateData);
        PlayerLookForState = new LandAttack_PlayerLookForState(this, StateMachine, "playerLookFor");
        PlayerFollowState = new LandAttack_PlayerFollowState(this, StateMachine, "playerFollow", moveStateData); ;
        AttackState = new LandAttack_AttackState(this, StateMachine, "attack", meleeAttackStateData);
        DamagedState = new LandAttack_DamagedState(this, StateMachine, "damaged", damagedStateData);
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
