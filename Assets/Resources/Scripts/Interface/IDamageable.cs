using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ���� �� �ִ� ������Ʈ�� �Ҵ�
public interface IDamageable
{
    public void Damage(WeaponAttackDetails details);

    public void Death();
}
