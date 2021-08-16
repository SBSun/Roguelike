using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor ,enterColor;
    private SpriteRenderer SR;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        Debug.Log("down");
    }

    public void OnMouseEnter()
    {
        SR.color = enterColor;
        Debug.Log("enter");
    }

    public void OnMouseExit()
    {
        SR.color = baseColor;
        Debug.Log("exit");
    }
}
