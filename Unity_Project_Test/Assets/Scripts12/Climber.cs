using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float moveForce = 10.0f;
    private Rigidbody2D rb;
    private Arrow arrow;
    public AudioSource myAudio;

    private SpriteRenderer mySpriteRenderer;
    public Sprite clingSprite;
    public Sprite jumpSprite;
    private float previousVelocityX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = GetComponentInChildren<Arrow>();
        myAudio = GetComponent<AudioSource>(); 
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space pressed");
            arrow.PauseRotation();
            // Calculate the launch direction based on the arrow's rotation
            Vector2 launchDirection = arrow.GetLaunchDirection();

            // Apply a force in the calculated direction
            rb.AddForce(launchDirection * moveForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.x > 0)
        {
            mySpriteRenderer.sprite = jumpSprite;
            mySpriteRenderer.flipX = false;

        }
        else if (rb.velocity.x < 0)
        {
            mySpriteRenderer.sprite = jumpSprite;
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.sprite = clingSprite;
            mySpriteRenderer.flipX = (previousVelocityX < 0); // Flip if previously moving left
        }
        previousVelocityX = rb.velocity.x;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the collision is with an object
        arrow.ResumeRotation();
        Debug.Log("should start rotating");
            // Check for space bar input
            if (Input.GetKeyDown(KeyCode.Space))
            {
            myAudio.Play();
                // Apply a force in the desired direction
                rb.AddForce(Vector2.up * moveForce, ForceMode2D.Impulse);
            }


        
    }

}
