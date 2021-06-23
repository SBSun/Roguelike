using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;

    private Vector3 movementPos;
    private Vector3 lastCameraPosition;
    [SerializeField]
    private Vector2 parallaxMultiplier;
    private float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
    }

    private void LateUpdate()
    {
        movementPos = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(movementPos.x * parallaxMultiplier.x, movementPos.y * parallaxMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if((Mathf.Abs(cameraTransform.position.x - transform.position.x)) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y); 
        }
    }
}
