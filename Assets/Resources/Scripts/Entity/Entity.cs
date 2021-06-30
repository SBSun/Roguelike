using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Entity : MonoBehaviour, IDamageable
{
    public Core Core { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }

    [SerializeField]
    private SO_EntityData entityData;
    public SO_EntityData EntityData { get => entityData; private set => entityData = value; }

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    public virtual void Damage(float amount)
    {
        Core.HealthCondition.DecreaseHP(amount);

        if(Core.HealthCondition.CurrentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("Á×À½");
    }
}
