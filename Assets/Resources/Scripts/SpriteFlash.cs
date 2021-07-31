using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer SR;

    private Material originalMaterial;
    private Material flashMaterial;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        originalMaterial = SR.material;
        flashMaterial = Resources.Load<Material>("Materials/WhiteFlash");
    }

    public void OnFlash()
    {
        SR.material = flashMaterial;
    }

    public void OffFlash()
    {
        SR.material = originalMaterial;
    }
}
