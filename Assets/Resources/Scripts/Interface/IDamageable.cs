using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//데미지를 입을 수 있는 오브젝트에 할당
public interface IDamageable
{
    public void Damage(float amount);

    public void Death();
}
