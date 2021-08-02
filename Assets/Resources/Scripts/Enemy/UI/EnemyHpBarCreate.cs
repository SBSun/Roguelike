using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarCreate : MonoBehaviour
{
    public GameObject hpBarPrefab;

    public void HpBarCreate(Enemy enemy)
    {
        EnemyHpBar hpBar = Instantiate(hpBarPrefab, enemy.transform.position, Quaternion.identity, transform).GetComponent<EnemyHpBar>();
        enemy.SetEnemyHpBar(hpBar);
    }
}
