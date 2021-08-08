using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }
    public EnemyCollisionSense CollisionSense
    {
        get => GenericNotImplementedError<EnemyCollisionSense>.TryGet(collisionSense, transform.parent.name);
        private set => collisionSense = value;
    }
    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    private Movement movement;
    private EnemyCollisionSense collisionSense;
    private Combat combat;

    protected virtual void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSense = GetComponentInChildren<EnemyCollisionSense>();
        Combat = GetComponentInChildren<Combat>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
    }
}
