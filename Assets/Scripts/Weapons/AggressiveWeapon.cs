using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        foreach (IDamageable item in detectedDamageable)
        {
            
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
