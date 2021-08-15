using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Enemy
{
    //Player Detected 관련 변수
    protected RaycastHit2D hitInfo;

    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] protected LayerMask whatIsGroundOrPlayer;

    [SerializeField] protected Vector2 recognizeBoxSize;
    [SerializeField] protected BoxCollider2D attackArea;
    public Collider2D playerCol { get; private set; }

    protected override void Start()
    {
        base.Start();
        recognizeBoxSize.Set(15f, Collider.bounds.size.y);
    }

    public bool PlayerDetected
    {
        get
        {
            Collider2D col = Physics2D.OverlapBox(Collider.bounds.center, recognizeBoxSize, 0, whatIsPlayer);

            if (col != null)
            {
                playerCol = col;
                hitInfo = Physics2D.Raycast(Collider.bounds.center, (col.transform.position - transform.position).normalized, Vector2.Distance(col.transform.position, transform.position), whatIsGroundOrPlayer);
                Debug.DrawRay(Collider.bounds.center, (col.transform.position - transform.position).normalized * hitInfo.distance);

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

            if (col != null)
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
            if (playerCol.transform.position.x < transform.position.x)
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
        if (Collider != null)
        {
            Gizmos.DrawWireCube(Collider.bounds.center, recognizeBoxSize);
            Gizmos.DrawWireCube(attackArea.bounds.center, attackArea.bounds.size);
        }
    }
}
