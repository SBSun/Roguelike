using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarCreate : MonoBehaviour
{
    public GameObject hpBarPrefab;

    public void HpBarCreate(Enemy enemy)
    {
        HpBar hpBar = Instantiate(hpBarPrefab, enemy.transform.position, Quaternion.identity, transform).GetComponent<HpBar>();
        enemy.SetEnemyHpBar(hpBar);
    }
}
