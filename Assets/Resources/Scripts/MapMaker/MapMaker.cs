using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapMaker : EditorWindow
{
    static MapMaker mapMaker;

    static List<GameObject> allPrefabs = new List<GameObject>();

    int selGridInt = 0;

    [MenuItem("CustomEditor/Map Maker")]
    public static void ShowWindow()
    {
        mapMaker = (MapMaker)GetWindow(typeof(MapMaker));
        mapMaker.Show();

        mapMaker.minSize = new Vector2(100, 100);
        mapMaker.titleContent = new GUIContent("MapMaker 2D");
    }

    //Update와 같은 역할
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField("Select a prefab:");

        //If prefabs have been loaded


        if (allPrefabs != null && allPrefabs.Count > 0)
        {


            GUIContent[] content = new GUIContent[allPrefabs.Count];

            for (int i = 0; i < allPrefabs.Count; i++)
            {
                if (allPrefabs[i] != null && allPrefabs[i].name != "")
                    content[i] = new GUIContent(Resources.Load<Texture2D>("Sprites/Entity/Enemy/" + allPrefabs[i].name + "/" + allPrefabs[i].name));


                if (content[i] == null)
                    content[i] = GUIContent.none;
            }

            //creates selection grid
            EditorGUI.BeginChangeCheck();

            
            //prevents from error if object are deleted by user
            while (selGridInt >= allPrefabs.Count)
                selGridInt--;

            selGridInt = GUILayout.SelectionGrid(selGridInt, content, 3, GUILayout.Height(50 * (Mathf.Ceil(allPrefabs.Count / (float)3))), GUILayout.Width(this.position.width));

            /*
            if (EditorGUI.EndChangeCheck())
            {

                ChangeGizmoTile();


            }

            curPrefab = allPrefabs[selGridInt];*/
        }
    }

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
    }
}
