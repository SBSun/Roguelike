using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveAttackEnemy : AttackEnemy
{
    public LandAttack_IdleState IdleState { get; private set; }
    public LandAttack_MoveState MoveState { get; private set; }
    public LandAttack_PlayerLookForState PlayerLookForState { get; private set; }
    public LandAttack_PlayerFollowState PlayerFollowState { get; private set; }
    public LandAttack_AttackState AttackState { get; private set; }
    public LandAttack_DamagedState DamagedState { get; private set; }
    public LandAttack_DeathState DeathState { get; private set; }

    [SerializeField] private D_E_IdleState idleStateData;
    [SerializeField] private D_E_MoveState moveStateData;
    [SerializeField] private D_E_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_E_DeathState deathStateData;

    public AttackInfoToEnemy AttackInfo { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        AttackInfo = GetComponent<AttackInfoToEnemy>();

        IdleState = new LandAttack_IdleState(this, StateMachine, "idle", idleStateData);
        MoveState = new LandAttack_MoveState(this, StateMachine, "move", moveStateData);
        PlayerLookForState = new LandAttack_PlayerLookForState(this, StateMachine, "playerLookFor");
        PlayerFollowState = new LandAttack_PlayerFollowState(this, StateMachine, "playerFollow", moveStateData); ;
        AttackState = new LandAttack_AttackState(this, StateMachine, "attack", meleeAttackStateData);
        DamagedState = new LandAttack_DamagedState(this, StateMachine, "damaged");
        DeathState = new LandAttack_DeathState(this, StateMachine, "death", deathStateData);
    }

    protected override void Start()
    {
        base.Start();

        AttackInfo.AttackState = AttackState;
        RandomStartState();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Damage()
    {
        if (StateMachine.CurrentState == DamagedState)
            Anim.SetTrigger("empty");

        StateMachine.ChangeState(DamagedState);
    }

    public override void Death()
    {
        StateMachine.ChangeState(DeathState);
    }

    //Idle, Move 중 하나로 시작
    private void RandomStartState()
    {
        int rand = Random.Range(0, 2);

        switch(rand)
        {
            case 0:
                StateMachine.Initialize(IdleState);
                break;

            case 1:
                StateMachine.Initialize(MoveState);
                break;
        }
    }

}
