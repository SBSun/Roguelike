using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour //�÷��̾��� �Է°��� ���� ��� ����
{
    private Vector2 movementInput;

    //WASD�� ������ ����
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    //Space�� ������ ����
    public void OnJumpInput(InputAction.CallbackContext context)
    {

    }
}
