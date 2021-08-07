using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new AggressiveWeaponData", menuName = "Data/Weapon Data/Aggressive Weapon")]
public class D_AggressiveWeapon : D_Weapon
{
    [SerializeField] protected WeaponAttackDetails[] attackDetails;

    public WeaponAttackDetails[] AttackDetails { get => attackDetails; set => attackDetails = value; }

    private void OnEnable()
    {
        amountOfAttack = attackDetails.Length;

        movementSpeed = new float[amountOfAttack];

        for (int i = 0; i < amountOfAttack; i++)
        {
            movementSpeed[i] = attackDetails[i].movementSpeed;
        }
    }
}
