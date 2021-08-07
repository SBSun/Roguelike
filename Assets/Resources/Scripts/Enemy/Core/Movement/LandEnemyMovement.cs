using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandEnemyMovement : Movement
{

    public void PlayerDirectionFlip(int direction)
    {
        if (FacingDirection != direction)
        {
            FacingDirection = direction;
            RB.transform.Rotate(0f, 180f, 0f);
        }
    }
}
