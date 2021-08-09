using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    private PlayerCore core;

    protected override void Awake()
    {
        base.Awake();
        core = GetComponentInParent<PlayerCore>();
    }

    //�¿� ����Ű�� ������ �� ĳ������ �̹����� �ش� ������ ���� �ִ��� Ȯ���ϰ� Flip ����
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
            Flip();
    }

    public void SetGravityScale(float gravity)
    {
        RB.gravityScale = gravity;
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = core.Player.Collider.offset;
        workspace.Set(core.Player.Collider.size.x, height);

        center.y += (height - core.Player.Collider.size.y) / 2;

        core.Player.Collider.size = workspace;
        core.Player.Collider.offset = center;
    }

}
