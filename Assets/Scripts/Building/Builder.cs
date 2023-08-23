using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject buildingPrefab;

    public static Builder instance;
    public List<BuildSlot> buildSlots = new List<BuildSlot>();

    public bool isBuilding = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isBuilding = !isBuilding;
        }
    }
}

