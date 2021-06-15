using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterSpritePool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterSprtePrefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    [SerializeField]
    private int maxAfterSprtes;

    public static PlayerAfterSpritePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    //Sprite �����ϰ� Queue�� push
    private void GrowPool()
    {
        for (int i = 0; i < maxAfterSprtes; i++)
        {
            var instanceToAdd = Instantiate(afterSprtePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    //Queue�� Push
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

    //���ʴ�� Queue���� pop
    public void GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            GrowPool();
        }

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
    }
}
