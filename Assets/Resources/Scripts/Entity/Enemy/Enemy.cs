using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{

    public EnemyStateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }
    public HpBar EnemyHpBar { get; private set; }
    public Core Core { get; protected set; }

    public float CurrentHP { get; protected set; }

    [SerializeField]
    protected D_Enemy enemyData;

    protected virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        StateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {
        Anim = GetComponent<Animator>();

        Managers.UI.EnemyHpBarCreate.HpBarCreate(this);
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();

        EnemyHpBar.transform.position = Camera.main.WorldToScreenPoint((Vector2)Core.Combat.Collider.bounds.center - new Vector2(0, Core.Combat.Collider.bounds.extents.y + 0.5f));
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
