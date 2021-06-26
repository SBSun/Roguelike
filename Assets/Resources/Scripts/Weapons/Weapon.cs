using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected WeaponManager weaponManager;

    public SO_WeaponData weaponData;

    public Animator baseAnimator { get; private set; }
    public Animator weaponAnimator { get; private set; }

    protected PlayerAttackState state;

    protected virtual void Awake()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        weaponManager = GetComponentInParent<WeaponManager>();     
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        weaponManager.CanNotWeaponChange();

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        weaponManager.CheckIfCanComboAttack();

        baseAnimator.SetInteger("attackCounter", weaponManager.AttackCounter);
        weaponAnimator.SetInteger("attackCounter", weaponManager.AttackCounter);

        state.SetPlayerVelocity(0f);
    }

    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        weaponManager.CanWeaponChange();

        gameObject.SetActive(false);
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.movementSpeed[weaponManager.AttackCounter]);
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
