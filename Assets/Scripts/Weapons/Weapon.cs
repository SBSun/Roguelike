using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected WeaponStateMachine weaponMachine;

    public SO_WeaponData weaponData { get; private set; }

    protected Animator baseAnimator;
    protected Animator weaponAnimator;

    protected PlayerAttackState state;

    protected virtual void Awake()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        weaponMachine = GetComponentInParent<WeaponStateMachine>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);
    }

    public virtual void ExitWeapon()
    {
        gameObject.SetActive(false);
    }


    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.movementSpeed[weaponMachine.AttackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {
        
    }

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }
}
