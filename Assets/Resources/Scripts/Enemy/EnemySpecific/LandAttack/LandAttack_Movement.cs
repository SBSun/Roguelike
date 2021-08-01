using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_Movement : MonoBehaviour
{
    private LandAttackEnemy landAttackEnemy;

    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workSpace;

    private void Awake()
    {
        FacingDirection = 1;
        landAttackEnemy = GetComponentInParent<LandAttackEnemy>();
    }

    public void LogicUpdate()
    {
        CurrentVelocity = landAttackEnemy.RB.velocity;
    }

    public void SetVelocityZero()
    {
        workSpace.Set(0, 0);
        landAttackEnemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        landAttackEnemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        landAttackEnemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        landAttackEnemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void Flip()
    {
        FacingDirection *= -1;
        landAttackEnemy.RB.transform.Rotate(0f, 180f, 0f);
    }

    public void PlayerDirectionFlip(int direction)
    {
        if (FacingDirection != direction)
        {
            FacingDirection = direction;
            landAttackEnemy.RB.transform.Rotate(0f, 180f, 0f);
        }
    }
}
