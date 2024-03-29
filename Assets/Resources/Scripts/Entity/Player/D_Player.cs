using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new D_Player", menuName = "Data/Player Data/Base Data")]
public class D_Player : ScriptableObject
{ 
    [Header("Health Condition")]
    public float maxHP = 100f;

    [Header("Move State")]
    public float movementVelocity = 10f; //움직이는 속도

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1; //점프 최대 횟수
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    //슬로우 모션 상태 유지 시간
    public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 30f;
    public float drag = 10f;
    public float distBetweenAfterSprites = 0.5f;

    [Header("Crouch State")]
    public float crouchMovementVelocity = 2f;
    public float crouchColliderHeight = 0.8f;
    public float standColliderHeight = 1.6f;

    [Header("Gravity")]
    public float defaultGravity = 5f;
}
