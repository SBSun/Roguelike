using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IDamageable
{

    public EnemyStateMachine StateMachine { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public BoxCollider2D Collider { get; private set; }

    public float CurrentHP { get; private set; }

    [SerializeField]
    protected D_Enemy enemyData;

    protected virtual void Awake()
    {
        StateMachine = new EnemyStateMachine();
     
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Start()
    {
        CurrentHP = enemyData.maxHP;
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    public virtual void Damage(WeaponAttackDetails details)
    {

        if (CurrentHP - details.damageAmount <= 0)
        {
            Death();
            return;
        }
        else
            CurrentHP -= details.damageAmount;
    }

    public virtual void Death()
    {
        Debug.Log("Á×À½");
    }
}
