using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float rotationSpeed = 60.0f; // Speed of rotation in degrees per second
    private Transform pivotPoint;

    private void Start()
    {
        // Find the pivot point (parent) of the arrow
        pivotPoint = transform.parent;

        if (pivotPoint == null)
        {
            Debug.LogError("Arrow is not a child of a pivot point.");
            enabled = false; // Disable the script
        }
    }

    private void Update()
    {
        // Rotate the arrow around the pivot point
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}




