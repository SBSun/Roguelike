using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator baseAnimator;
    protected Animator weaponAnimator;

    protected virtual void Start()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        weaponAnimator.SetBool("attack", true);
        baseAnimator.SetBool("attack", true);
    }

    public virtual void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);
        baseAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }
}
