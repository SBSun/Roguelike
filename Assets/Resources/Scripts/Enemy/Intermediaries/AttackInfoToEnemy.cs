using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfoToEnemy : MonoBehaviour
{
    public EnemyAttackState AttackState;
    private Collider2D playerCol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCol = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCol = null;
    }

    public Collider2D GetPlayerCol()
    {
        return playerCol;
    }
}
