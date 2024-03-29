using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour //플레이어의 입력값에 따른 기능 실행
{
    private PlayerInput playerInput;
    private Player player;
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
    public bool CrouchInput { get; private set; }
    public bool[] AttackInputs { get; private set; }


    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    private float dashInputStartTime;
    private int weaponChangeInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        player = GetComponent<Player>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length; //CombatInputs 열거형에 몇개의 요소가 있는지
        AttackInputs = new bool[count];
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

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
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
    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            CrouchInput = true;
        }

        if(context.canceled)
        {
            CrouchInput = false;
        }
    }
    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        if (playerInput.currentControlScheme == "Keyboard")
        {
            //캐릭터에서 마우스까지의 방향
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }

        DashdirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }
    //마우스 왼쪽 클릭
    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if(context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }
    //마우스 오른쪽 클릭
    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }
   
    public void OnWeaponChangeInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            string str = context.control.ToString();

            int newWeapon = int.Parse(str.Substring(str.Length - 1)) - 1;
            
            //현재 무기와 바꾸려는 무기가 다르면 변경
            if(player.WeaponInventory.weapons[newWeapon] != player.WeaponManager.CurrentWeapon)
            {
                player.WeaponManager.ChangeWeapon(player.WeaponInventory.weapons[newWeapon]);
            }
                
        }
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

public enum CombatInputs
{
    primary,
    secondary
}
