using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int curLevel = 1;

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
            previousVelocityX = 1f;

        }
        else if (rb.velocity.x < 0)
        {
            mySpriteRenderer.sprite = jumpSprite;
            mySpriteRenderer.flipX = true;
            previousVelocityX = -1f;

        }
        else
        {
            mySpriteRenderer.sprite = clingSprite;
            if (previousVelocityX < 0)
            {
                mySpriteRenderer.flipX = true;
            }
    
        }
        Debug.Log("Previous Velocity: " + previousVelocityX);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the collision is with an object
        rb.velocity = Vector2.zero;
        arrow.ResumeRotation();
        Debug.Log("should start rotating");
        // Check for space bar input

        Rock hitRock = col.gameObject.GetComponent<Rock>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAudio.Play();
            // Apply a force in the desired direction
            rb.AddForce(Vector2.up * moveForce, ForceMode2D.Impulse);
        }

        if (hitRock != null)
        {
            if (hitRock.level == curLevel)
            {
                // Do something when the levels match
                Debug.Log("Collided with a Rock at the same level!");
            }
        }

        if (col.gameObject.GetComponent<cliffScript>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }


}
