using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    public BoxCollider2D Collider { get; private set; }

    private Vector2 holdPosition;

    protected override void Awake()
    {
        base.Awake();
        Collider = transform.parent.GetComponentInParent<BoxCollider2D>();
    }

    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
        SetFinalVelocity();
    }

    public void SetGravityScale(float gravity)
    {
        RB.gravityScale = gravity;
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = Collider.offset;
        workspace.Set(Collider.size.x, height);

        center.y += (height - Collider.size.y) / 2;

        Collider.size = workspace;
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
}
