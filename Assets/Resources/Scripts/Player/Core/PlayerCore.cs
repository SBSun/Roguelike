using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public PlayerMovement Movement
    {
        get => GenericNotImplementedError<PlayerMovement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }

    public PlayerCollisionSense CollisionSenses
    {
        get => GenericNotImplementedError<PlayerCollisionSense>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }

    public PlayerCombat Combat
    {
        get => GenericNotImplementedError<PlayerCombat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    private PlayerMovement movement;
    private PlayerCollisionSense collisionSenses;
    private PlayerCombat combat;

    private void Awake()
    {
        Movement = GetComponentInChildren<PlayerMovement>();
        CollisionSenses = GetComponentInChildren<PlayerCollisionSense>();
        Combat = GetComponentInChildren<PlayerCombat>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
