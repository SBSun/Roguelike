using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D RB { get; protected set; }

    public int FacingDirection { get; protected set; }

    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; protected set; }

    protected Vector2 workspace;

    protected override void Awake()
    {
        base.Awake();
        RB = GetComponentInParent<Rigidbody2D>();
        FacingDirection = 1;
        CanSetVelocity = true;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    public void SetVelocityZero()
    {
        workspace.Set(0, 0);
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        SetFinalVelocity();
    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }

    public void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0f, 180f, 0f);
    }
}
