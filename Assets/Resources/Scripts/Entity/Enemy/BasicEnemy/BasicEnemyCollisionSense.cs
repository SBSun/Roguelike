using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyCollisionSense : MonoBehaviour
{
    [SerializeField]
    private BasicEnemy enemy;

    [SerializeField] private Transform topWallCheck;
    [SerializeField] private Transform bottomWallCheck;
    [SerializeField] private Transform topWallBackCheck;
    [SerializeField] private Transform bottomWallBackCheck;
    [SerializeField] private Transform cliffCheck;

    [SerializeField] private float cliffCheckDistance;

    [SerializeField] private LayerMask whatIsGround;

    //ĳ���� �տ� ���� �ִ��� üũ
    public bool WallFront
    {
        get => Physics2D.OverlapArea(bottomWallCheck.position, topWallCheck.position, whatIsGround);
    }
    //ĳ���� �ڿ� ���� �ִ��� üũ
    public bool WallBack
    {
        get => Physics2D.OverlapArea(bottomWallBackCheck.position, topWallBackCheck.position, whatIsGround);
    }

    public bool Cliffing
    {
        get => !Physics2D.Raycast(cliffCheck.position, Vector2.down, cliffCheckDistance, whatIsGround);
    }
}
