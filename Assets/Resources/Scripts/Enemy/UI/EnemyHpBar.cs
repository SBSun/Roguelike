using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    public Image fill_Image;

    public void SetHp(float currentHp, float maxHp)
    {
        fill_Image.fillAmount = Mathf.Lerp(0, 1, currentHp / maxHp);
    }

    public void ActiveHpBar()
    {
        gameObject.SetActive(true);
    }

    public void InactiveHpBar() => gameObject.SetActive(false);
}
