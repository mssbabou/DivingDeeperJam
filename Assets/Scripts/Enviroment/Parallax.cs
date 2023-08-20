using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxEffectMultiplier = 1f;

    ScrollableEnvironment scrollableEnvironment;

    float singleTexureHeight;

    void Start()
    {
        scrollableEnvironment = GetComponentInParent<ScrollableEnvironment>();

        SetupTexture();
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTexureHeight = sprite.texture.height / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = scrollableEnvironment.ScrollSpeed * parallaxEffectMultiplier * Time.deltaTime;
        transform.localPosition += Vector3.down * delta;
    }

    void CheckReset()
    {
        if((Mathf.Abs(transform.localPosition.y) - singleTexureHeight) > 0)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    void Update()
    {
        Scroll();
        CheckReset();
    }
}
