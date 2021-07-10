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


    [SerializeField]
    protected SO_EnemyData EnemyData;

    protected virtual void Awake()
    {
        StateMachine = new EnemyStateMachine();
     
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

    }


    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        Debug.Log("Update");
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void Damage(float amount)
    {
        /*
        if (HealthCondition.CurrentHP <= 0)
        {
            Death();
        }*/
    }

    public virtual void Death()
    {
        Debug.Log("Á×À½");
    }
}
