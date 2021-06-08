using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour //�÷��̾��� �Է°��� ���� ��� ����
{
    private Player player;

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; } //������ ����ġ�� �ֱ� ���� ����
    public bool GrabInput { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        CheckJumpInputHoldTime(); 
    }
    //WASD�� ������ ����
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        if (Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            NormInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }

        if (Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            NormInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    }

    //Space�� ������ ����
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

    public void UseJumpInput() => JumpInput = false;

    //���� ������� �� ����Ű�� ������ 2�� ������ ������ 2�� �Ǵ°� �����ֱ� ���� -> ���� �ִ� ���� Ƚ���� 1�� �� ����
    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
            JumpInput = false;
    }
}