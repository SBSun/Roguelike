using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSense : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public Transform GroundCheck { get => groundCheck; private set => groundCheck = value; }
    public Transform WallCheck { get => wallCheck; private set => wallCheck = value; }
    public Transform LedgeCheck { get => ledgeCheck; private set => ledgeCheck = value; }
    public Transform CeilingCheck { get => ceilingCheck; private set => ceilingCheck = value; }

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform ceilingCheck;

    public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }
    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;

    [SerializeField] private LayerMask whatIsGround;

    //���� ��� �ִ��� üũ
    public bool Grounded
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    //ĳ���� �տ� ���� �ִ��� üũ
    public bool WallFront
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * player.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
    //ĳ���� �ڿ� ���� �ִ��� üũ
    public bool WallBack
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * -player.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public bool Ledge
    {
        get => Physics2D.Raycast(ledgeCheck.position, Vector2.right * player.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public bool Ceiling
    {
        get => Physics2D.OverlapCircle(ceilingCheck.position, groundCheckRadius, whatIsGround);
    }
   
}
