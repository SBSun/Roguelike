using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D RB { get; protected set; }

    public int FacingDirection { get; protected set; }

    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; protected set; }

    protected Vector2 workspace;

    protected virtual void Awake()
    {
        FacingDirection = 1;
        CanSetVelocity = true;
        RB = transform.parent.parent.GetComponent<Rigidbody2D>();
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
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
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
