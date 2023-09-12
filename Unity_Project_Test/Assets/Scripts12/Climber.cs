using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float moveForce = 10.0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            // Check for space bar input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Apply a force in the desired direction
                rb.AddForce(Vector2.up * moveForce, ForceMode2D.Impulse);
            }
        
    }

}
