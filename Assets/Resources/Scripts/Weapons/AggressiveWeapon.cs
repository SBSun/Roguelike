using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData aggressiveWeaponData;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_AggressiveWeaponData))
        {
            aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("���� ������ Ʋ��");
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

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[weaponManager.AttackCounter];

        foreach (IDamageable item in detectedDamageable)
        {
            item.Damage(details.damageAmount);
        }
    }

    public void AddToDectected(Collider2D collider)
    {
        IDamageable damagaable = collider.GetComponent<IDamageable>();

        if(damagaable != null)
        {
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