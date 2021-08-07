using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyDeathState Data", menuName = "Data/EnemyState Data/EnemyDeathState")]
public class D_E_DeathState : ScriptableObject
{
    public GameObject deathParticle;
    public GameObject bloodSplash;
}
