using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour //플레이어의 입력값에 따른 기능 실행
{
    private Vector2 movementInput;

    //WASD를 누르면 실행
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    //Space를 누르면 실행
    public void OnJumpInput(InputAction.CallbackContext context)
    {

    }
}
