using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal,
    Boss
}

public enum AttackType
{
    Melee, //근접
    Range, //원거리
    Magic  //마법
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IDamageable
{
    public Core Core { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }

    public EnemyStateMachine StateMachine { get; private set; }

    [SerializeField] protected SO_EnemyData EnemyData;
    public EnemyType EnemyType { get => enemyType; set => enemyType = value; }
    public AttackType AttackType { get => attackType; set => attackType = value; }

    [SerializeField] private EnemyType enemyType;
    [SerializeField] private AttackType attackType;

    protected virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        StateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void Damage(float amount)
    {
        Core.HealthCondition.DecreaseHP(amount);

        if (Core.HealthCondition.CurrentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("죽음");
    }
}
