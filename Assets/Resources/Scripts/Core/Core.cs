using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }
    public CollisionSense CollisionSenses
    {
        get => GenericNotImplementedError<CollisionSense>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }
    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }
    public HealthCondition HealthCondition
    {
        get => GenericNotImplementedError<HealthCondition>.TryGet(healCondition, transform.parent.name);
        private set => healCondition = value;
    }

    private Movement movement;
    private CollisionSense collisionSenses;
    private Combat combat;
    private HealthCondition healCondition;

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSense>();
        Combat = GetComponentInChildren<Combat>();
        HealthCondition = GetComponentInChildren<HealthCondition>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
    }

}
