using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCore core;

    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D Collider { get; private set; }
    public int FacingDirection { get; private set; }
    public bool CanSetVelocity { get; set; }
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workSpace;
    private Vector2 holdPosition;

    private void Awake()
    {
        core = GetComponentInParent<PlayerCore>();
        FacingDirection = 1;
        RB = GetComponentInParent<Rigidbody2D>();
        Collider = GetComponentInParent<BoxCollider2D>();
        CanSetVelocity = true;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }
    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            RB.velocity = workSpace;
            CurrentVelocity = workSpace;
        }
    }
    #region Set �Լ� 
    public void SetVelocityZero()
    {
        workSpace.Set(0, 0);
        SetFinalVelocity();
    }
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }
    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;
        SetFinalVelocity();
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        SetFinalVelocity();
    }
    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        SetFinalVelocity();
    }
    public void SetGravityScale(float gravity)
    {
        RB.gravityScale = gravity;
    }
    public void SetColliderHeight(float height)
    {
        Vector2 center = Collider.offset;
        workSpace.Set(Collider.size.x, height);

        center.y += (height - Collider.size.y) / 2;

        Collider.size = workSpace;
        Collider.offset = center;
    }

    public void HoldPosition()
    {
        RB.gravityScale = 0;
        RB.transform.position = holdPosition;
        SetVelocityZero();
    }

    public void SetHoldPosition()
    {
        holdPosition = transform.position;
    }


    //�¿� ����Ű�� ������ �� ĳ������ �̹����� �ش� ������ ���� �ִ��� Ȯ���ϰ� Flip ����
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
            Flip();
    }

    public void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0f, 180f, 0f);
    }

    #endregion
}
