using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public Player Player { get; private set; }

    public PlayerMovement Movement
    {
        get => GenericNotImplementedError<PlayerMovement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }

    public PlayerCollisionSense CollisionSense
    {
        get => GenericNotImplementedError<PlayerCollisionSense>.TryGet(collisionSense, transform.parent.name);
        private set => collisionSense = value;
    }

    public PlayerCombat Combat
    {
        get => GenericNotImplementedError<PlayerCombat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    private PlayerMovement movement;
    private PlayerCollisionSense collisionSense;
    private PlayerCombat combat;

    private void Awake()
    {
        Player = GetComponentInParent<Player>();
        Movement = GetComponentInChildren<PlayerMovement>();
        CollisionSense = GetComponentInChildren<PlayerCollisionSense>();
        Combat = GetComponentInChildren<PlayerCombat>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
    }
}
