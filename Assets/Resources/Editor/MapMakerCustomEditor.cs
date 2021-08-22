using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        MapMakerData data = EditorUtility.InstanceIDToObject(instanceId) as MapMakerData;
        if(data != null)
        {
            MapMaker.ShowMapMaker(data);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(MapMakerData))]
public class MapMakerCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Editor"))
        {
            MapMaker.ShowMapMaker((MapMakerData)target);
        }
    }
}
