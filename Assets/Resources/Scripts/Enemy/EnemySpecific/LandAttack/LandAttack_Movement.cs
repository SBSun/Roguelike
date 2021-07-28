using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_Movement : MonoBehaviour
{
    private Enemy enemy;

    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workSpace;

    private void Awake()
    {
        FacingDirection = 1;
        enemy = GetComponentInParent<Enemy>();
    }

    public void LogicUpdate()
    {
        CurrentVelocity = enemy.RB.velocity;
    }

    public void SetVelocityZero()
    {
        workSpace.Set(0, 0);
        enemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * direction);
        enemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        enemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        enemy.RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void Flip()
    {
        FacingDirection *= -1;
        enemy.RB.transform.Rotate(0f, 180f, 0f);
    }

    public void PlayerDirectionFlip(int direction)
    {
        if (FacingDirection != direction)
        {
            FacingDirection = direction;
            enemy.RB.transform.Rotate(0f, 180f, 0f);
        }
    }
}
