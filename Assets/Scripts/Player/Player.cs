using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State 변수
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerDashState DashState { get; private set; }

    #endregion
    
    #region 컴포넌트
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    [SerializeField]
    private PlayerData playerData;
    public Transform DashDirectionIndicator { get; private set; }
    #endregion

    #region 나머지 변수
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    public float gravity;
    private Vector2 holdPosition;

    private Vector2 workSpace;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    #endregion

    #region 유니티 콜백 함수
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");
        DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");

        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
        Debug.DrawRay(wallCheck.position, Vector2.right * FacingDirection * playerData.wallCheckDistance, Color.red);
        Debug.DrawRay(ledgeCheck.position, Vector2.right * FacingDirection * playerData.wallCheckDistance, Color.red);
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion   

    #region Check 함수

    //땅에 닿아 있는지 체크
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }
    //좌우 방향키를 눌렀을 때 캐릭터의 이미지가 해당 방향을 향해 있는지 확인하고 Flip 실행
    public void CheckIfShouldFlip(int xInput)
    {

        if (xInput != 0 && xInput != FacingDirection)
            Flip();
    }
    //캐릭터 앞에 벽이 있는지 체크
    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }
    //캐릭터 뒤에 벽이 있는지 체크
    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    #endregion

    #region Set 함수 
    public void SetVelocityZero()
    {
        workSpace.Set(0,0);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetGravityScale(float gravity)
    {
        RB.gravityScale = gravity;
    }
    #endregion

    #region 나머지 함수
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    public Vector2 DetermineCornerPosition()
    {
        //캐릭터와 벽의 사이 길이 구하기
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
        float xDist = xHit.distance;
        //캐릭터와 벽 사이 길이 + 0.01(무조건 땅에 닿게 하기 위해 더함) * 캐릭터 방향  
        workSpace.Set((xDist + 0.01f) * FacingDirection , 0f);
        //ledgeCheck.y와 벽의 사이 길이 구하기
        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3)workSpace, Vector2.down, ledgeCheck.position.y - wallCheck.position.y, playerData.whatIsGround);

        workSpace.Set(yHit.point.x, yHit.point.y);
        return workSpace;
    }

    public void HoldPosition()
    {
        RB.gravityScale = 0;
        transform.position = holdPosition;
        SetVelocityZero();
    }

    public void SetHoldPosition()
    {
        holdPosition = transform.position;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    #endregion
}
