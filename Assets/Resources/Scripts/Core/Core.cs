using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public HealthCondition HealthCondition { get; private set; }
    public Entity Entity { get; private set; }

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        HealthCondition = GetComponentInChildren<HealthCondition>();
        Entity = GetComponentInParent<Entity>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
