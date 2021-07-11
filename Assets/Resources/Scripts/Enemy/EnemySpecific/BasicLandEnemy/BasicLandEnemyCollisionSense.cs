using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLandEnemyCollisionSense : MonoBehaviour
{
    private Enemy enemy;

    [SerializeField] private Transform topWallCheck;
    [SerializeField] private Transform bottomWallCheck;
    [SerializeField] private Transform topWallBackCheck;
    [SerializeField] private Transform bottomWallBackCheck;
    [SerializeField] private Transform cliffCheck;

    [SerializeField] private float cliffCheckDistance;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsGroundOrPlayer;

    private RaycastHit2D hitInfo;
    [SerializeField] private Vector2 recognizeBoxSize;
    [SerializeField] private Vector2 attackAreaCenter;
    [SerializeField] private Vector2 attackAreaSize;


    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

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
            Collider2D col = Physics2D.OverlapBox(enemy.Collider.bounds.center, recognizeBoxSize, 0, whatIsPlayer);

            if (col != null)
            {

                hitInfo = Physics2D.Raycast(enemy.Collider.bounds.center, (col.transform.position - transform.position).normalized, Vector2.Distance(col.transform.position, transform.position), whatIsGroundOrPlayer);
                Debug.DrawRay(enemy.Collider.bounds.center, (col.transform.position - transform.position).normalized * hitInfo.distance);

                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }
    }

    public bool PlayerInAttackArea
    {
        get
        {
            Collider2D col = Physics2D.OverlapBox(attackAreaCenter, attackAreaSize, 0, whatIsPlayer);

            if(col != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(enemy.Collider.bounds.center, recognizeBoxSize);

        /*
        bool isHit = Physics2D.BoxCast(basicEnemy.Collider.bounds.center, basicEnemy.Collider.bounds.size, 0f, Vector2.right * basicEnemy.Core.Movement.FacingDirection, maxAggroDistance, whatIsPlayer);


        if (isHit)
        {
            Gizmos.DrawWireCube((Vector2)basicEnemy.Collider.bounds.center + Vector2.right * basicEnemy.Core.Movement.FacingDirection * hitInfo.distance, basicEnemy.Collider.bounds.size);
        }
        else
        {
            Gizmos.DrawWireCube((Vector2)basicEnemy.Collider.bounds.center + Vector2.right * basicEnemy.Core.Movement.FacingDirection * maxAggroDistance, basicEnemy.Collider.bounds.size);
        }*/
    }

}
