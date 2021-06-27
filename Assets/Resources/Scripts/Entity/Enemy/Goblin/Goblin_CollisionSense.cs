using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_CollisionSense : MonoBehaviour
{
    [SerializeField]
    private Goblin goblin;
    public Transform WallCheck { get => wallCheck; private set => wallCheck = value; }
    public Transform LedgeCheck { get => ledgeCheck; private set => ledgeCheck = value; }
    public Transform CliffCheck { get => cliffCheck; private set => cliffCheck = value; }

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform cliffCheck;

    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }
    public float CliffCheckDistance { get => cliffCheckDistance; set => cliffCheckDistance = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float cliffCheckDistance;

    [SerializeField] private LayerMask whatIsGround;

    //ĳ���� �տ� ���� �ִ��� üũ
    public bool WallFront
    {
        get => Physics2D.OverlapBox(wallCheck.position, Vector2.right * goblin.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
    //ĳ���� �ڿ� ���� �ִ��� üũ
    public bool WallBack
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * -goblin.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
}
