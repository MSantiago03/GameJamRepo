using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float rotationSpeed = 60.0f; // Speed of rotation in degrees per second
    private Transform pivotPoint;
    private bool isRotating = true;


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
        if (isRotating)
        {
            // Rotate the arrow around the pivot point
            transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public Vector2 GetLaunchDirection()
    {
        // Calculate the launch direction based on the current rotation
        float rotationAngle = transform.rotation.eulerAngles.z;
        Vector2 launchDirection = Quaternion.Euler(0, 0, rotationAngle - 90) * Vector2.up;

        return launchDirection.normalized; // Normalize the direction vector
    }

    public void PauseRotation()
    {
        isRotating = false;
    }

    public void ResumeRotation()
    {
        isRotating = true;
        Debug.Log("should start rotating");
    }
}




