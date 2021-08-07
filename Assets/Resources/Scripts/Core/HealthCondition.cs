using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCondition : CoreComponent
{
    public D_HealthCondition healthData { get; private set; }
    public float CurrentHP { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        CurrentHP = healthData.maxHP;
    }

    public void IncreaseHP(float increase)
    {
        if (CurrentHP + increase >= healthData.maxHP)
            CurrentHP = healthData.maxHP;
        else
            CurrentHP += increase;
    }

    public void DecreaseHP(float decrease)
    {
        if (CurrentHP - decrease <= 0)
            CurrentHP = 0;
        else
            CurrentHP -= decrease;
    }
}
