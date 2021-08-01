using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    public GameObject hpBar;
    public Image fill_Image;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void SetHp(float currentHp, float maxHp)
    {
        fill_Image.fillAmount = Mathf.Lerp(0, 1, currentHp / maxHp);
    }

    public void ActiveHpBar()
    {
        hpBar.SetActive(true);
    }

    public void InactiveHpBar() => hpBar.SetActive(false);
}
