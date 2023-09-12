using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float moveForce = 10.0f;
    private Rigidbody2D rb;
    private Arrow arrow;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = GetComponentInChildren<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arrow.PauseRotation();
            // Calculate the launch direction based on the arrow's rotation
            Vector2 launchDirection = arrow.GetLaunchDirection();

            // Apply a force in the calculated direction
            rb.AddForce(launchDirection * moveForce, ForceMode2D.Impulse);
        }

    }

}
