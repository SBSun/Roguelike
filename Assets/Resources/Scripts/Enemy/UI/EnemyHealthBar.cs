using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject hpBar;
    public Vector3 offset;

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHp(float )
}
