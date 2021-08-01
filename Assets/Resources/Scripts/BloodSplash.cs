using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour
{
    private SpriteRenderer SR;
    private Sprite[] bloodSprites;

    private float startTime;
    [SerializeField] private float destroyTime;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        bloodSprites = Resources.LoadAll<Sprite>("Sprites/BloodSplash");
    }

    private void Start()
    {
        RandomSprite();
        startTime = Time.time;
    }

    private void Update()
    {
        FadeOut();
    }

    private void RandomSprite()
    {
        int rand = Random.Range(0, bloodSprites.Length);
        SR.sprite = bloodSprites[rand];
        float rotation = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        float size = Random.Range(0.4f, 0.8f);
        transform.localScale = new Vector2(size,size);
    }

    private void FadeOut()
    {
        if (startTime + destroyTime >= Time.time)
        {
            Color color = SR.color;
            color.a = Mathf.Lerp(1, 0, (Time.time - startTime) / destroyTime);
            SR.color = color;
        }
        else
            Destroy(gameObject);
    }
}
