using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapMakerEditorWindow : ExtendedEditorWindow
{
    static MapMakerEditorWindow mapMaker;

    static Dictionary<int, List<GameObject>> allPrefabs = new Dictionary<int, List<GameObject>>();

    static int selGridInt = 0;

    [MenuItem("CustomEditor/Map Maker")]
    public static void ShowMapMaker(MapMakerData data)
    {
        mapMaker = GetWindow<MapMakerEditorWindow>("Map Maker Editor");
        mapMaker.serializedObject = new SerializedObject(data); 
        mapMaker.Show();
    }

    //Update와 같은 역할
    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("details");

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

        DrawSlidebar(currentProperty);

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));

        if(selectedProperty != null)
        {
            DrawSelectedPropertiesPanel();
        }
        else
        {
            EditorGUILayout.LabelField("Select an item from the list");
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }

    private void DrawSelectedPropertiesPanel()
    {
        currentProperty = selectedProperty;

        EditorGUILayout.BeginHorizontal("box", GUILayout.MinWidth(400), GUILayout.ExpandWidth(true));
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));

        DrawField("type", true);
        DrawField("name", true);
        DrawField("prefab", true);
        DrawField("icon", true);


        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
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
