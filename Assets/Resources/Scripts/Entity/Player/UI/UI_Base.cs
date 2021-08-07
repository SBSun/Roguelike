using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> UI_Objects = new Dictionary<Type, UnityEngine.Object[]>();

	//Object�� ��ӹ޾ƾ߸� �Ѵ�.
	protected void Bind<T>(Type type) where T : UnityEngine.Object
	{
		string[] names = Enum.GetNames(type);
		UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
		UI_Objects.Add(typeof(T), objects); // Dictionary �� �߰�

		// T �� ���ϴ� ������Ʈ���� Dictionary�� Value�� objects �迭�� ���ҵ鿡 �ϳ��ϳ� �߰�
		for (int i = 0; i < names.Length; i++)
		{
			if (typeof(T) == typeof(GameObject))
				objects[i] = Util.FindChild(gameObject, names[i], true);
			else
				objects[i] = Util.FindChild<T>(gameObject, names[i], true);

			if (objects[i] == null)
				Debug.Log($"Failed to bind({names[i]})");
		}
	}
}

public class Util
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        //���� �ڽĵ� �߿����� ã��
        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        //��� �ڽĵ� �߿��� T������Ʈ�� ���� �ڽ� ã�� 
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
	{
		Transform transform = FindChild<Transform>(go, name, recursive);
		if (transform == null)
			return null;

		return transform.gameObject;
	}
}
