using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDepth : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] Transform indicator;
    [SerializeField] Transform minPos;
    [SerializeField] Transform maxPos;

    [Header("Depth Options")]
    [SerializeField] float maxDepth;

    // Update is called once per frame
    void Update()
    {
        float percentComplete = GameManager.Singleton.currentDepth / maxDepth;
        indicator.position = Vector3.Lerp(minPos.position, maxPos.position, percentComplete);
    }
}