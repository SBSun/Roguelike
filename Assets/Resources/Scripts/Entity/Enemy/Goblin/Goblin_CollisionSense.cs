using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_CollisionSense : MonoBehaviour
{
    [SerializeField]
    private Goblin goblin;

    [SerializeField] private Transform topWallCheck;
    [SerializeField] private Transform bottomWallCheck;
    [SerializeField] private Transform cliffCheck;

    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float cliffCheckDistance;

    [SerializeField] private LayerMask whatIsGround;

    //ĳ���� �տ� ���� �ִ��� üũ
    public bool WallFront
    {
        get => Physics2D.Raycast(topWallCheck.position, Vector2.right * goblin.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround) ||
            Physics2D.Raycast(bottomWallCheck.position, Vector2.right * goblin.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
    //ĳ���� �ڿ� ���� �ִ��� üũ
    public bool WallBack
    {
        get => Physics2D.Raycast(topWallCheck.position, Vector2.right * -goblin.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround) ||
            Physics2D.Raycast(bottomWallCheck.position, Vector2.right * -goblin.Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public bool Cliffing
    {
        get => !Physics2D.Raycast(cliffCheck.position , Vector2.down, cliffCheckDistance, whatIsGround);
    }
}
