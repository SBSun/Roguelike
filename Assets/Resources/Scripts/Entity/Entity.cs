using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public Core Core { get; private set; }

    [SerializeField]
    private SO_EntityData entityData;
    public SO_EntityData EntityData { get => entityData; private set => entityData = value; }

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
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
