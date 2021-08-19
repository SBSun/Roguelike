using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapMaker : EditorWindow
{
    static MapMaker mapMaker;

    static Dictionary<int, List<GameObject>> allPrefabs = new Dictionary<int, List<GameObject>>();

    static int selGridInt = 0;

    [MenuItem("CustomEditor/Map Maker")]
    public static void ShowWindow(GameData)
    {
        mapMaker = (MapMaker)GetWindow(typeof(MapMaker));
        mapMaker.Show();

        mapMaker.minSize = new Vector2(100, 100);
        mapMaker.titleContent = new GUIContent("MapMaker 2D");
    }

    //Update와 같은 역할
    private void OnGUI()
    {
        
    }


    
    /*
    private void OnFocus()
    {
        LoadPrefabs();
        Debug.Log("MapMaker Activated");
    }

    
    //Prefab 가져오기
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
