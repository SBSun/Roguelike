using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveAttackEnemyCore : MonoBehaviour
{
    public LandEnemyMovement Movement
    {
        get => GenericNotImplementedError<LandEnemyMovement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }
    public LandMoveAttackEnemyCollisionSense CollisionSenses
    {
        get => GenericNotImplementedError<LandMoveAttackEnemyCollisionSense>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }
    public MoveEnemyCombat Combat
    {
        get => GenericNotImplementedError<MoveEnemyCombat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }
    public HealthCondition HealthCondition
    {
        get => GenericNotImplementedError<HealthCondition>.TryGet(healCondition, transform.parent.name);
        private set => healCondition = value;
    }


    private LandEnemyMovement movement;
    private LandMoveAttackEnemyCollisionSense collisionSenses;
    private MoveEnemyCombat combat;
    private HealthCondition healCondition;

    protected virtual void Awake()
    {
        Movement = GetComponentInChildren<LandEnemyMovement>();
        CollisionSenses = GetComponentInChildren<LandMoveAttackEnemyCollisionSense>();
        Combat = GetComponentInChildren<MoveEnemyCombat>();
        HealthCondition = GetComponentInChildren<HealthCondition>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
    }
}
