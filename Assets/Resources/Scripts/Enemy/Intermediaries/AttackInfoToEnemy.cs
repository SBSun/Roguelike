using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfoToEnemy : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
