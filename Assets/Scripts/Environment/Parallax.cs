using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallaxEffectMultiplier = 1f;

    ScrollableEnvironment scrollableEnvironment;

    float singleTextureHeight;

    void Start()
    {
        scrollableEnvironment = GetComponentInParent<ScrollableEnvironment>();

        SetupTexture();
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureHeight = sprite.textureRect.height / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = scrollableEnvironment.ScrollSpeed * parallaxEffectMultiplier * Time.deltaTime;
        transform.position += Vector3.up * delta;
    }

    void CheckReset()
    {
        if((Mathf.Abs(transform.localPosition.y) - singleTextureHeight) > 0)
        {
            transform.localPosition = Vector3.zero;
        }
    }

    void Update()
    {
        Scroll();
        CheckReset();
    }
}
