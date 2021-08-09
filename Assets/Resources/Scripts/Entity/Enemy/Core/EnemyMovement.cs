using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    private EnemyCore core;

    protected override void Awake()
    {
        base.Awake();
        core = GetComponentInParent<EnemyCore>();
    }

    public void PlayerDirectionFlip(int direction)
    {
        if (core.Movement.FacingDirection != direction)
        {
            core.Movement.FacingDirection = direction;
            RB.transform.Rotate(0f, 180f, 0f);
        }
    }
}
