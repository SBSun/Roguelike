using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; protected set; }
    public EnemyCore Core { get; protected set; }
    public Rigidbody2D RB { get; protected set; }
    public BoxCollider2D Collider { get; protected set; }
    public Animator Anim { get; protected set; }
    public HpBar EnemyHpBar { get; protected set; }

    public float CurrentHP { get; protected set; }

    [SerializeField]
    protected D_Enemy enemyData;

    protected virtual void Awake()
    {
        Core = GetComponentInChildren<EnemyCore>();
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        StateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {
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

    public virtual void OnDamage()
    {

    }

    public void SetEnemyHpBar(HpBar hpBar)
    {
        EnemyHpBar = hpBar;
    }
}
