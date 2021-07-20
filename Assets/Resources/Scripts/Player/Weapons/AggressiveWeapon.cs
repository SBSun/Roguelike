using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    protected D_AggressiveWeapon aggressiveWeaponData;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(D_AggressiveWeapon))
        {
            aggressiveWeaponData = (D_AggressiveWeapon)weaponData;
        }
        else
        {
            Debug.LogError("무기 종류가 틀림");
        }
    }
    public override void EnterWeapon()
    {
        base.EnterWeapon();

        weaponAnimator.SetBool("attack", true);
        baseAnimator.SetBool("attack", true);

        baseAnimator.SetInteger("attackCounter", weaponManager.AttackCounter);
        weaponAnimator.SetInteger("attackCounter", weaponManager.AttackCounter);
    }

    public override void ExitWeapon()
    {
        base.ExitWeapon();

        weaponAnimator.SetBool("attack", false);
        baseAnimator.SetBool("attack", false);
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[weaponManager.AttackCounter];

        foreach (IDamageable item in detectedDamageable)
        {
            item.Damage(details.damageAmount);
            Debug.Log("Enemy에게 공격 성곡");
        }
    }

    public void AddToDectected(Collider2D collider)
    {
        IDamageable damagaable = collider.GetComponent<IDamageable>();

        if(damagaable != null)
        {
            if(!detectedDamageable.Contains(damagaable))
                detectedDamageable.Add(damagaable);
        }
    }

    public void RemoveFromDecteted(Collider2D collider)
    {
        IDamageable damagaable = collider.GetComponent<IDamageable>();

        if (damagaable != null)
        {
            detectedDamageable.Remove(damagaable);
        }
    }
}
