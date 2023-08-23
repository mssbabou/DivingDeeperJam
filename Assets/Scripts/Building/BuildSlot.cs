using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    Up,
    Down,
    Left,
    Right,
}

public class BuildSlot : MonoBehaviour
{
    [SerializeField] private float defaultTransparency = 0.5f;
    [SerializeField] private float hoverTransparency = 0.75f;

    [Space(10)]
    public Direction direction = Direction.Up;

    [HideInInspector] public GameObject BuildingInstance;
    [HideInInspector] public bool isOccupied = false;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        if(Builder.instance == null)
        {
            Debug.LogError("No Builder instance found in scene!");
            return;
        }

        Builder.instance.buildSlots.Add(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Builder.instance == null)
            return;

        UpdateState();
    }

    void UpdateState()
    {
        if (isOccupied)
        {
            spriteRenderer.enabled = false;
            return;
        }

        if (Builder.instance.isBuilding)
        {
            spriteRenderer.enabled = true;
            Color color = spriteRenderer.color;
            color.a = CheckMouseHover() ? hoverTransparency : defaultTransparency;
            spriteRenderer.color = color;

            if(Input.GetMouseButtonDown(0) && CheckMouseHover())
            {
                Build();
            }
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

    void Build()
    {
        if (BuildingInstance != null)
        {
            Destroy(BuildingInstance);
        }

        BuildingInstance = Instantiate(Builder.instance.buildingPrefab, transform.position, Quaternion.Euler(0f, 0f, DirectionToRotation(direction)));
        BuildingInstance.transform.parent = transform;
        isOccupied = true;
    }

    void Destroy()
    {
        if (BuildingInstance != null)
        {
            Destroy(BuildingInstance);
        }
    }

    bool CheckMouseHover()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return boxCollider.bounds.Contains(mousePos);
    }

    private float DirectionToRotation(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return 0f;
            case Direction.Down:
                return 180f;
            case Direction.Left:
                return 90f;
            case Direction.Right:
                return 270f;
            default:
                return 0f;
        }
    }
}