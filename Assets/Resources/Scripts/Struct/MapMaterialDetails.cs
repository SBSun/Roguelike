using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MapMaterialType
{
    Enemy = 0,
    Decoration = 1,
    Obstacle = 2
}

[Serializable]
public struct MapMaterialDetails
{
    public string name;
    public GameObject prefab;
    public Texture Icon;
    public MapMaterialType type;
}
