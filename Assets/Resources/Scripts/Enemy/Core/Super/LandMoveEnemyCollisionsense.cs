using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveEnemyCollisionsense : MonoBehaviour
{
    protected Enemy enemy;

    [SerializeField] protected Transform topWallCheck;
    [SerializeField] protected Transform bottomWallCheck;
    [SerializeField] protected Transform topWallBackCheck;
    [SerializeField] protected Transform bottomWallBackCheck;
    [SerializeField] protected Transform cliffCheck;

    [SerializeField] protected float cliffCheckDistance;

    [SerializeField] protected LayerMask whatIsGround;

    protected RaycastHit2D hitInfo;

    protected void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    
    //ĳ���� �տ� ���� �ִ��� üũ
    public bool WallFront
    {
        get => Physics2D.OverlapArea(topWallCheck.position, bottomWallCheck.position, whatIsGround);
    }
    //ĳ���� �ڿ� ���� �ִ��� üũ
    public bool WallBack
    {
        get => Physics2D.OverlapArea(topWallBackCheck.position, bottomWallBackCheck.position, whatIsGround);
    }

    public bool Cliffing
    {
        get => !Physics2D.Raycast(cliffCheck.position, Vector2.down, cliffCheckDistance, whatIsGround);
    }
}
