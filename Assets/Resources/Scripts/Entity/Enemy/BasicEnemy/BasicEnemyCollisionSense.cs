using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyCollisionSense : MonoBehaviour
{
    [SerializeField]
    private BasicEnemy basicEnemy;

    [SerializeField] private Transform topWallCheck;
    [SerializeField] private Transform bottomWallCheck;
    [SerializeField] private Transform topWallBackCheck;
    [SerializeField] private Transform bottomWallBackCheck;
    [SerializeField] private Transform cliffCheck;

    [SerializeField] private float cliffCheckDistance;
    [SerializeField] private float maxAggroDistance;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsPlayer;

    RaycastHit2D hitInfo;
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

    public bool PlayerDetected
    {
        get
        {
            hitInfo = Physics2D.BoxCast(new Vector2(basicEnemy.Collider.bounds.center.x + basicEnemy.Collider.bounds.size.x / 2, basicEnemy.Collider.bounds.center.y), basicEnemy.Collider.bounds.size, 0f, Vector2.right * basicEnemy.Core.Movement.FacingDirection, maxAggroDistance, whatIsPlayer);
            if (hitInfo)
            {
                Debug.Log(hitInfo.collider.name);
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

    private void OnDrawGizmos()
    {

        bool isHit = Physics2D.BoxCast(basicEnemy.Collider.bounds.center, basicEnemy.Collider.bounds.size, 0f, Vector2.right * basicEnemy.Core.Movement.FacingDirection, maxAggroDistance, whatIsPlayer);


        if (isHit)
        {
            Gizmos.DrawWireCube((Vector2)basicEnemy.Collider.bounds.center + Vector2.right * basicEnemy.Core.Movement.FacingDirection * hitInfo.distance, basicEnemy.Collider.bounds.size);
        }
        else
        {
            Gizmos.DrawWireCube((Vector2)basicEnemy.Collider.bounds.center + Vector2.right * basicEnemy.Core.Movement.FacingDirection * maxAggroDistance, basicEnemy.Collider.bounds.size);
        }
    }
}
