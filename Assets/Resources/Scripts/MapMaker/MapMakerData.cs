using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MapMakerData", menuName = "Data/MapData/MapMakerData")]
public class MapMakerData : ScriptableObject
{
    public MapMaterialDetails[] details = new MapMaterialDetails[5];
}
