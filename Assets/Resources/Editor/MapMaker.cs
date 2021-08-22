using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapMaker : ExtendedEditorWindow
{
    static MapMaker mapMaker;

    static Dictionary<int, List<GameObject>> allPrefabs = new Dictionary<int, List<GameObject>>();

    static int selGridInt = 0;

    [MenuItem("CustomEditor/Map Maker")]
    public static void ShowMapMaker(MapMakerData data)
    {
        mapMaker = GetWindow<MapMaker>("Map Maker Editor");
        mapMaker.serializedObject = new SerializedObject(data); 
        mapMaker.Show();
    }

    //Update�� ���� ����
    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("details");
        DrawProperties(currentProperty, true);
    }


    
    /*
    private void OnFocus()
    {
        LoadPrefabs();
        Debug.Log("MapMaker Activated");
    }

    
    //Prefab ��������
    private void LoadPrefabs()
    {
        allPrefabs.Clear();
       
        GameObject[] loadedObjects = Resources.LoadAll<GameObject>("Prefabs/MapMaker/Enemy");

        foreach (var loadedObject in loadedObjects)
        {
            if (loadedObject.GetType() == typeof(GameObject))
                allPrefabs.Add(loadedObject);
        }

        Debug.Log(allPrefabs.Count);
    }*/
}
