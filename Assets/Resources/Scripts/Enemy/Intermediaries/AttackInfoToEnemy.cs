using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfoToEnemy : MonoBehaviour
{
    private BasicEnemy basicEnemy;

    private void Awake()
    {
        basicEnemy = GetComponentInParent<BasicEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
