using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionSense : CollisionSense
{
    private EnemyCore core;

    private void Awake()
    {
        core = GetComponentInParent<EnemyCore>();
    }

    [SerializeField] protected Transform topWallCheck;
    [SerializeField] protected Transform bottomWallCheck;
    [SerializeField] protected Transform topWallBackCheck;
    [SerializeField] protected Transform bottomWallBackCheck;
    [SerializeField] protected Transform cliffCheck;

    [SerializeField] protected float cliffCheckDistance;

    //캐릭터 앞에 벽이 있는지 체크
    public bool WallFront
    {
        get => Physics2D.OverlapArea(topWallCheck.position, bottomWallCheck.position, whatIsGround);
    }
    //캐릭터 뒤에 벽이 있는지 체크
    public bool WallBack
    {
        get => Physics2D.OverlapArea(topWallBackCheck.position, bottomWallBackCheck.position, whatIsGround);
    }

    public bool Cliffing
    {
        get => !Physics2D.Raycast(cliffCheck.position, Vector2.down, cliffCheckDistance, whatIsGround);
    }
   
}
