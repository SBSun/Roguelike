using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public Enemy Enemy { get; private set; }

    public EnemyMovement Movement
    {
        get => GenericNotImplementedError<EnemyMovement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }
    public EnemyCollisionSense CollisionSense
    {
        get => GenericNotImplementedError<EnemyCollisionSense>.TryGet(collisionSense, transform.parent.name);
        private set => collisionSense = value;
    }
    public EnemyCombat Combat
    {
        get => GenericNotImplementedError<EnemyCombat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    private EnemyMovement movement;
    private EnemyCollisionSense collisionSense;
    private EnemyCombat combat;

    protected virtual void Awake()
    {
        Enemy = GetComponentInParent<Enemy>();
        Movement = GetComponentInChildren<EnemyMovement>();
        CollisionSense = GetComponentInChildren<EnemyCollisionSense>();
        Combat = GetComponentInChildren<EnemyCombat>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
    }
}
