using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlot : MonoBehaviour
{
    public Buildable buildablePrefab;
    public Color highlightColor = Color.green;

    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    private bool isHighlighted = false;
    public bool IsFilled { get; private set; } = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Highlight()
    {
        if (!isHighlighted && !IsFilled)
        {
            spriteRenderer.color = highlightColor;
            isHighlighted = true;
        }
    }

    public void RemoveHighlight()
    {
        if (isHighlighted)
        {
            spriteRenderer.color = originalColor;
            isHighlighted = false;
        }
    }

    public void Build()
    {
        if (!IsFilled && buildablePrefab != null)
        {
            Instantiate(buildablePrefab, transform.position, Quaternion.identity);
            buildablePrefab.Build();
            IsFilled = true;
            RemoveHighlight();
        }
    }
}
