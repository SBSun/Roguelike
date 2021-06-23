using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine : MonoBehaviour
{
    public Weapon CurrentWeapon { get; private set; }

    private float comboSpaceTime;   //다음 공격을 몇초 안에 해야지 다음 콤보가 나갈지 
    private float lastAttackTime;
    public int AttackCounter { get; private set; }

    public void Initialize(Weapon startingWeapon)
    {
        if(startingWeapon.GetType() == typeof(AggressiveWeapon))
        {
            CurrentWeapon = (AggressiveWeapon)startingWeapon;
        }
        else
        {
            CurrentWeapon = startingWeapon;
        }
        CurrentWeapon = startingWeapon;
        CurrentWeapon.EnterWeapon();
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        CurrentWeapon.ExitWeapon();
        CurrentWeapon = newWeapon;
        CurrentWeapon.EnterWeapon();
    }

    public void CheckIfCanComboAttack()
    {
        if (lastAttackTime + comboSpaceTime >= Time.time && CurrentWeapon.weaponData.amountOfAttack > AttackCounter)
        {
            ComboAttack();
        }
        else
        {
            ResetAttackCounter();
        }
    }

    public void ComboAttack()
    {
        AddToAttackCounter();
    }

    public void AddToAttackCounter()
    {
        if(AttackCounter + 1 > CurrentWeapon.weaponData.amountOfAttack)
        {
            ResetAttackCounter();
        }
        else
        {
            AttackCounter++;
        }
    }

    public void ResetAttackCounter() => AttackCounter = 0;
}
