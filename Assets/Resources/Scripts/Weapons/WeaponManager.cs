using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon CurrentWeapon { get; private set; }

    [SerializeField]
    private PlayerInventory weaponInventory;

    private float comboSpaceTime = 1f;   //���� ������ ���� �ȿ� �ؾ��� ���� �޺��� ������ 
    private float lastAttackTime = 0f;
    public int AttackCounter { get; private set; }

    private void Awake()
    {
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
        CurrentWeapon = startingWeapon;
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if(CurrentWeapon != newWeapon)
        {
            ResetAttackCounter();
        }

        CurrentWeapon = newWeapon;
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
        if (AttackCounter + 1 > CurrentWeapon.weaponData.amountOfAttack)
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
