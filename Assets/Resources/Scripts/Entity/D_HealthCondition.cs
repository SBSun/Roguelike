using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new D_HealthCondition", menuName = "Data/HealthCondition Data/Base Data")]
public class D_HealthCondition : ScriptableObject
{
    [Header("Health Condition")]
    public float maxHP = 100f;
}
