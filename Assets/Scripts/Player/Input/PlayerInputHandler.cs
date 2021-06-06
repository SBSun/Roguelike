using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour //�÷��̾��� �Է°��� ���� ��� ����
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }

    //WASD�� ������ ����
    public void OnMovexinput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;
    }

    //Space�� ������ ����
    public void OnJumpxinput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

}
