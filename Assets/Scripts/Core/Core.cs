using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public CollisionSense CollisionSense { get; private set; }

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSense = GetComponentInChildren<CollisionSense>();
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
