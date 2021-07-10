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
    [SerializeField] private LayerMask whatIsGroundOrPlayer;

    private RaycastHit2D hitInfo;
    [SerializeField] private Vector2 recognizeBoxSize;


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
            Collider2D col = Physics2D.OverlapBox(basicEnemy.Collider.bounds.center, recognizeBoxSize, 0, whatIsPlayer);

            if (col != null)
            {
 
                hitInfo = Physics2D.Raycast(basicEnemy.Collider.bounds.center, (col.transform.position - transform.position).normalized, Vector2.Distance(col.transform.position, transform.position), whatIsGroundOrPlayer);
                Debug.DrawRay(basicEnemy.Collider.bounds.center, (col.transform.position - transform.position).normalized * hitInfo.distance);

                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                    return true;
                else
                    return false;

            }
            else
                return false;
        }
    }

    public int PlayerDirection
    {
        get
        {
            if(Mathf.Abs(hitInfo.collider.transform.position.x - transform.position.x) > hitInfo.collider.bounds.size.x)
            {
                //플레이어가 Enemy의 왼쪽에 있으면
                if (hitInfo.collider.transform.position.x < transform.position.x)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }    
            else
            {
                return 0;
            }
        }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(basicEnemy.Collider.bounds.center, recognizeBoxSize);

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
