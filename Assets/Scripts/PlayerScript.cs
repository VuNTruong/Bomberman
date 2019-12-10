using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    // missileRight to be thrown
    public GameObject missileRight;

    // missileRight to be thrown to the left
    public GameObject missileLeft;

    // Rigidbody Component of the player
    Rigidbody2D rb;

    // public access to the LivesManager component
    public LivesManager liveData;

    // public access to the missileManager component
    public MissileManager missileManager;

    // public access to the isAliveManager control
    public IsAliveManager isAliveManager;

    // Animator component of the object
    Animator anim;

    // Audio component of the object
    AudioSource audioSource;

    // public game object for the bomb
    public GameObject bomb;

    // Number of frame to decrease number of lives of the player when the player got hit by the monster
    int numOfFrameGotHit = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of the object
        rb = GetComponent<Rigidbody2D>();

        // Get the Animation component of the object
        anim = GetComponent<Animator>();

        // Set initial state of the player to be alive
        anim.SetBool("isdie", false);

        // Get the AudioSource component of the player
        audioSource = GetComponent<AudioSource>();

        isAliveManager.changeToTrue();
    }

    // Update is called once per frame
    void Update()
    {
        // If the current level of live of the player reaches 0, the player dies
        if (liveData.getLives() <= 0)
        {
            // Set the die animation to true
            anim.SetBool("isdie", true);

            // Set the status of the IsAliveManager to false to end the game
            isAliveManager.changeToFalse();

            // Destroy the player game object after that 1.5 seconds
            GameObject.Destroy(this.gameObject, 1f);
        }
        
        // Only fire missile if the player still have missile left
        if (missileManager.getMissile() > 0)
        {
            // Fire the missile to the right if player presses the f key
            if (Input.GetKeyDown("f"))
            {
                // Create the missile game object and let it launch on its own
                GameObject gameObject = (GameObject)Instantiate(missileRight,
                    new Vector3(rb.position.x, rb.position.y, 0f) + new Vector3(1.3f, 0f, 0f),
                    transform.rotation);

                // Decrement the number of missile currently have 
                missileManager.decrementMissile();
            }

            // Fire the misisle to the left if the player presses the b key
            if (Input.GetKeyDown("b"))
            {
                // Create the missile game object and let it launch on its own
                GameObject gameObject = (GameObject)Instantiate(missileLeft,
                    new Vector3(rb.position.x, rb.position.y, 0f) - new Vector3(1.3f, 0f, 0f),
                    transform.rotation);

                // Decrement the number of missile currently have
                missileManager.decrementMissile();
            }
        }

        // Place the bomb if the space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the bomb and the location of the player
            GameObject gameObject = (GameObject)Instantiate(bomb,
                new Vector3(rb.position.x, rb.position.y, 0f), transform.rotation);

            // Player the sound 
            audioSource.Play();
        }
    }

    void OnCollisionStay2D (Collision2D col)
    {
        // Get the game object collided with
        GameObject gameObject = col.gameObject;

        // If the game object collided with is monster, the player got hit
        if (gameObject.CompareTag("monster"))
        {
            // Decrease the number of frame got hit by 1
            numOfFrameGotHit -= 1;

            // If the numebr of frame got hit is 0, decrease the number of lives of the player
            if (numOfFrameGotHit == 0)
            {
                // Decrement the number of lives
                liveData.decrementLive();

                // Bring the number back to 20
                numOfFrameGotHit = 20;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Get the game object get collided with
        GameObject gameObject = col.gameObject;

        // Compare tag
        if (gameObject.CompareTag("hp"))
        {
            if (liveData.getLives() <= 15)
            {
                for (int i = 0; i < 5; i++)
                {
                    // Increment the live for the player
                    liveData.incrementLive();
                }
            }
            else
            {
                // Fill up the lives
                liveData.setLives(20);
            }

            // Destroy the object get collided with
            GameObject.Destroy(gameObject);
        }
        if (gameObject.CompareTag("missileTool"))
        {
            // Increment the number of missile when collected
            missileManager.incrementMissile();

            // Destroy the object get collided with
            GameObject.Destroy(gameObject);
        }

        if (gameObject.CompareTag("randomMissile"))
        {
            for (int i = 0; i < 5; i++)
            {
                liveData.decrementLive();
            }
        }
    }
}
