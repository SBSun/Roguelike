using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour //플레이어의 입력값에 따른 기능 실행
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashdirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; } //점프의 가중치를 주기 위한 변수
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }


    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    private float dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }
    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }
    //WASD를 누르면 실행
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        if (Mathf.Abs(RawMovementInput.x) > 0f)
        {
            NormInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }    

        if (Mathf.Abs(RawMovementInput.y) > 0f)
        {
            NormInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    }

    //Space를 누르면 실행
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
            JumpInputStop = true;
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GrabInput = true;
        }
        
        if(context.canceled)
        {
            GrabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if(context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        if(playerInput.currentControlScheme == "Keyboard")
        {
            //캐릭터에서 마우스까지의 방향
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }

        DashdirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    //땅에 닿아있을 때 점프키를 빠르게 2번 누르면 점프가 2번 되는걸 막아주기 위함 -> 점프 최대 가능 횟수가 1일 때 적용
    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
            JumpInput = false;
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}
