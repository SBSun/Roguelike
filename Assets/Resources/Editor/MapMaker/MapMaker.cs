using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MapMaker : EditorWindow
{
    [MenuItem("Tools/MapMaker Editor")]
    public static void ShowExample()
    {
        MapMaker wnd = GetWindow<MapMaker>();
        wnd.titleContent = new GUIContent("MapMaker");
        wnd.minSize = new Vector2(800, 600);
    }

    private void OnEnable()
    {
        VisualTreeAsset original = Resources.Load<VisualTreeAsset>("Editor/MapMaker/MapMaker.uxml");
        TemplateContainer treeAsset = original.CloneTree();
        rootVisualElement.Add(treeAsset);
    }
}