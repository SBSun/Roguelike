using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MapMaterialData", menuName = "Data/MapData/MapMaterialData")]
public class MapMaterialData : ScriptableObject
{
    [ContextMenuItem("Detail Set", "DetailSet")]
    public MapMaterialDetails details;

    public void DetailSet()
    {
        switch(details.type)
        {
            case MapMaterialType.Enemy:
                details.name = name;
                details.prefab = Resources.Load("Prefabs/Enemy/" + name) as GameObject;
                details.Icon = Resources.Load("Sprites/Enemy/" + name + "/" + name) as Texture;
                break;

            case MapMaterialType.Decoration:

                break;

            case MapMaterialType.Obstacle:

                break;
        }
    }
}
