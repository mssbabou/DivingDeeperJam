using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public LayerMask buildSlotLayer;
    public bool isBuilding = false;

    private List<BuildSlot> allBuildSlots;

    void Start()
    {
        allBuildSlots = new List<BuildSlot>(FindObjectsOfType<BuildSlot>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // Press 'B' to toggle building mode
        {
            ToggleBuildingMode();
        }

        if (isBuilding && Input.GetMouseButtonDown(0))
        {
            BuildAtMousePosition();
        }
    }

    void ToggleBuildingMode()
    {
        isBuilding = !isBuilding;

        if (isBuilding)
        {
            HighlightAllBuildSlots();
        }
        else
        {
            RemoveHighlightFromAllBuildSlots();
        }
    }

    void HighlightAllBuildSlots()
    {
        foreach (var buildSlot in allBuildSlots)
        {
            buildSlot.Highlight();
        }
    }

    void RemoveHighlightFromAllBuildSlots()
    {
        foreach (var buildSlot in allBuildSlots)
        {
            buildSlot.RemoveHighlight();
        }
    }

    void BuildAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, buildSlotLayer);

        if (hit.collider != null)
        {
            BuildSlot buildSlot = hit.collider.GetComponent<BuildSlot>();
            if (buildSlot != null)
            {
                buildSlot.Build();
            }
        }
    }
}

