using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance;  // 유일성이 보장된다.
    public static Managers GetInstance() { return Instance; }

    UIManager _ui;
    public static UIManager UI { get { return Instance._ui; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;        
        }

        _ui = GetComponentInChildren<UIManager>();
    }
}
