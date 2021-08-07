using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon CurrentWeapon { get; private set; }

    private WeaponInventory weaponInventory;

    [SerializeField]
    private float comboSpaceTime = 1f;   //다음 공격을 몇초 안에 해야지 다음 콤보가 나갈지 
    private float lastAttackTime = 0f;

    public bool CanChange { get; private set; }
    public int AttackCounter { get; private set; }

    private void Awake()
    {
        weaponInventory = GetComponent<WeaponInventory>();
        Initialize(weaponInventory.weapons[0]);
    }

    public void Initialize(Weapon startingWeapon)
    {
        if (startingWeapon.GetType() == typeof(AggressiveWeapon))
        {
            CurrentWeapon = (AggressiveWeapon)startingWeapon;
        }
        else
        {
            CurrentWeapon = startingWeapon;
        }
        ResetAttackCounter();
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if(CanChange)
        {
            ResetAttackCounter();
            CurrentWeapon = newWeapon;
        }
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

        lastAttackTime = Time.time;
  }

    public void ComboAttack()
    {
        AddToAttackCounter();
    }

    public void AddToAttackCounter()
    {
        if (AttackCounter + 1 == CurrentWeapon.weaponData.amountOfAttack)
        {
            ResetAttackCounter();
        }
        else
        {
            AttackCounter++;
        }
    }

    public void ResetAttackCounter() => AttackCounter = 0;

    public void CanWeaponChange() => CanChange = true;
    public void CanNotWeaponChange() => CanChange = false;
}
