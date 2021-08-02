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
    public EnemyHpBar EnemyHpBar { get; private set; }

    public float CurrentHP { get; protected set; }

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
        Managers.UI.EnemyHpBarCreate.HpBarCreate(this);
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();

        EnemyHpBar.transform.position = Camera.main.WorldToScreenPoint((Vector2)Collider.bounds.center - new Vector2(0, Collider.bounds.extents.y + 0.5f));
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void Damage(WeaponAttackDetails details)
    {

    }

    public virtual void Death()
    {

    }

    public void SetEnemyHpBar(EnemyHpBar enemyHpBar) => EnemyHpBar = enemyHpBar;

}
