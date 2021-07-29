using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
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
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }

    #endregion

    #region 컴포넌트
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }


    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerCollisionSense CollisionSense { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerHealthCondition HealthCondition { get; private set; }

    [SerializeField]
    private D_Player PlayerData;
    public Transform DashDirectionIndicator { get; private set; }
    
    public WeaponInventory WeaponInventory { get; private set; }

    public WeaponManager WeaponManager { get; private set; }
    #endregion

    #region 유니티 콜백 함수
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, PlayerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, PlayerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, PlayerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, PlayerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, PlayerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, PlayerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, PlayerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, PlayerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, PlayerData, "ledgeClimbState");
        DashState = new PlayerDashState(this, StateMachine, PlayerData, "inAir");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, PlayerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, PlayerData, "crouchMove");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, PlayerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, PlayerData, "attack");

        WeaponManager = GetComponentInChildren<WeaponManager>();
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        CollisionSense = GetComponentInChildren<PlayerCollisionSense>();
        Movement = GetComponentInChildren<PlayerMovement>();
        HealthCondition = GetComponentInChildren<PlayerHealthCondition>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        WeaponInventory = GetComponentInChildren<WeaponInventory>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Movement.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion   

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    public virtual void Damage(WeaponAttackDetails details)
    {
        //Core.HealthCondition.DecreaseHP(amount);

        if (HealthCondition.CurrentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }
}
