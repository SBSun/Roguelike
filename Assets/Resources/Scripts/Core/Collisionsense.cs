using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSense : CoreComponent
{
    public Transform GroundCheck { get => groundCheck; protected set => groundCheck = value; }
    public float GroundCheckRadius { get => groundCheckRadius; protected set => groundCheckRadius = value; }
    public LayerMask WhatIsGround { get => whatIsGround; protected set => whatIsGround = value; }

    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckRadius;
    [SerializeField] protected LayerMask whatIsGround;

    //¶¥¿¡ ´ê¾Æ ÀÖ´ÂÁö Ã¼Å©
    public bool Grounded
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
