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

    //Sprite 생성하고 Queue에 push
    private void GrowPool()
    {
        for (int i = 0; i < maxAfterSprtes; i++)
        {
            var instanceToAdd = Instantiate(afterSprtePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    //Queue에 Push
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

    //차례대로 Queue에서 pop
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
