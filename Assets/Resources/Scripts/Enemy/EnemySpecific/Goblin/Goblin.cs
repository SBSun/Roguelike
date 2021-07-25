using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    public Goblin_IdleState IdleState { get; private set; }
    public Goblin_MoveState MoveState { get; private set; }
    public Goblin_PlayerLookForState PlayerLookForState { get; private set; }
    public Goblin_PlayerFollowState PlayerFollowState { get; private set; }
    public Goblin_AttackState AttackState { get; private set; }
   public Goblin_DamagedState DamagedState { get; private set; }

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

        IdleState = new Goblin_IdleState(this, StateMachine, "idle", idleStateData);
        MoveState = new Goblin_MoveState(this, StateMachine, "move", moveStateData);
        PlayerLookForState = new Goblin_PlayerLookForState(this, StateMachine, "playerLookFor");
        PlayerFollowState = new Goblin_PlayerFollowState(this, StateMachine, "playerFollow", moveStateData); ;
        AttackState = new Goblin_AttackState(this, StateMachine, "attack",meleeAttackStateData);
        DamagedState = new Goblin_DamagedState(this, StateMachine, "damaged", damagedStateData);
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
        Debug.Log(Anim.GetBool("damaged"));
    }

    public override void Damage(float amount)
    {
        base.Damage(amount);

        if (Anim.GetBool("damaged"))
        {
            Anim.SetBool("damaged", false);
        }

        StateMachine.ChangeState(DamagedState);
    }

    public override void Death()
    {
        base.Death();


    }
}
