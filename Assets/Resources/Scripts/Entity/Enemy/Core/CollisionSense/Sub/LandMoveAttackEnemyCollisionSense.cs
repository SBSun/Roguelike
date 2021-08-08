using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMoveAttackEnemyCollisionSense : LandMoveEnemyCollisionsense
{

    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsGroundOrPlayer;

    private Vector2 recognizeBoxSize;
    [SerializeField] private BoxCollider2D attackArea;

    public Collider2D playerCol { get; private set; }

    private void Start()
    {
        recognizeBoxSize.Set(15f, core.Combat.Collider.bounds.size.y);
    }

    public bool PlayerDetected
    {
        get
        {
            Collider2D col = Physics2D.OverlapBox(core.Combat.Collider.bounds.center, recognizeBoxSize, 0, whatIsPlayer);

            if (col != null)
            {
                playerCol = col;
                hitInfo = Physics2D.Raycast(core.Combat.Collider.bounds.center, (col.transform.position - transform.position).normalized, Vector2.Distance(col.transform.position, transform.position), whatIsGroundOrPlayer);
                Debug.DrawRay(core.Combat.Collider.bounds.center, (col.transform.position - transform.position).normalized * hitInfo.distance);

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
            Collider2D col = Physics2D.OverlapBox(attackArea.bounds.center, attackArea.bounds.size, 0, whatIsPlayer);

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

    public int PlayerDirection
    {
        get
        {
            //플레이어가 Enemy의 왼쪽에 있으면
            if (playerCol.transform.position.x < core.Combat.transform.position.x)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(core != null)
        {
            Gizmos.DrawWireCube(core.Combat.Collider.bounds.center, recognizeBoxSize);
            Gizmos.DrawWireCube(attackArea.bounds.center, attackArea.bounds.size);
        }

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
