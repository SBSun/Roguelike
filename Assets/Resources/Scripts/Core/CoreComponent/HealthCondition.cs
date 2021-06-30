using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCondition : CoreComponent
{
    public float CurrentHP { get; private set; }
/*
    private SO_EntityData entityData;

    private void Start()
    {
        entityData = core.Entity.EntityData;
    }

    public void DecreaseHP(float decrease)
    {
        CurrentHP -= decrease;
    }

    public void IncreaseHP(float increase)
    {
        if(CurrentHP + increase >= entityData.maxHP)
        {
            CurrentHP = entityData.maxHP;
        }
        else
        {
            CurrentHP += increase;
        }
    }*/
}
