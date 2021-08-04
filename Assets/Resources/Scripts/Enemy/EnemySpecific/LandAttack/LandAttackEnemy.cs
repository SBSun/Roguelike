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
    public LandAttack_DeathState DeathState { get; private set; }

    [SerializeField] private D_E_IdleState idleStateData;
    [SerializeField] private D_E_MoveState moveStateData;
    [SerializeField] private D_E_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_E_DeathState deathStateData;

    public LandEnemyMovement Movement
    {
        get => GenericNotImplementedError<LandEnemyMovement>.TryGet(movement, transform.name);
        private set => movement = value;
    }
    public LandAttackEnemyCollisionSense CollisionSense
    {
        get => GenericNotImplementedError<LandAttackEnemyCollisionSense>.TryGet(collisionSenses, transform.name);
        private set => collisionSenses = value;
    }

    private LandEnemyMovement movement;
    private LandAttackEnemyCollisionSense collisionSenses;

    public AttackInfoToEnemy AttackInfo { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        AttackInfo = GetComponent<AttackInfoToEnemy>();
        Movement = GetComponentInChildren<LandEnemyMovement>();
        CollisionSense = GetComponentInChildren<LandAttackEnemyCollisionSense>();

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
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        Movement.LogicUpdate();
    }

    public override void Damage(WeaponAttackDetails details)
    {
        base.Damage(details);

        if (CurrentHP - details.damageAmount <= 0)
        {
            Death();
            return;
        }
        else
            CurrentHP -= details.damageAmount;

        EnemyHpBar.SetHp(CurrentHP, enemyData.maxHP);
        EnemyHpBar.ActiveHpBar();

        if (StateMachine.CurrentState== DamagedState)
        {
            Anim.SetTrigger("empty");
            Anim.Rebind();
        }

        int attackDirection;

        if (details.attackPosition.x > transform.position.x)
            attackDirection = -1;
        else
            attackDirection = 1;

        DamagedState.SetDamagedAttackDetails(details, attackDirection);
        StateMachine.ChangeState(DamagedState);
    }

    public override void Death()
    {
        base.Death();
        EnemyHpBar.InactiveHpBar();
        StateMachine.ChangeState(DeathState);
    }
}
