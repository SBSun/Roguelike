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

    //좌우 방향키를 눌렀을 때 캐릭터의 이미지가 해당 방향을 향해 있는지 확인하고 Flip 실행
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
