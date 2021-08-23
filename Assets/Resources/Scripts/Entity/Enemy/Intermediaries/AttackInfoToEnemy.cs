using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfoToEnemy : MonoBehaviour
{
    public EnemyAttackState AttackState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackState.SetPlayerCombat(collision.GetComponent<PlayerCombat>());
    }

    private void TriggerAttack()
    {
        AttackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        AttackState.FinishAttack();
    }
}
