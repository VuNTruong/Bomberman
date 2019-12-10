using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLaunchMissileScript : MonoBehaviour
{
    // Rigidbody component of the object 
    Rigidbody2D rb;

    // Explosion game object that will fire when the missile explode
    public GameObject explosion;

    // Speed of missile 
    public float speed = 0.5f;

    // Position of the object (missile)
    float missileX;
    float missileY;

    // public access to the LiveManager of the opponent
    public LivesManager liveManagerPlayer1;
    public LivesManagerPlayer2 liveManagerPlayer2;

    // Tag of the opponent 
    public string opponentTag = "";

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of the game object
        rb = GetComponent<Rigidbody2D>();

        // Get the initial position of the game object
        missileX = rb.position.x;
        missileY = rb.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the missile toward speed units per frame
        rb.position += new Vector2(speed, 0);

        // Get the position of the missile
        // The position should be updated every frame

        missileX = rb.position.x;
        missileY = rb.position.y;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Get reference to the game object collided with
        GameObject gameObject = col.gameObject;

        // If the missile collided with the monster, it will explode
        if (gameObject.CompareTag("monster"))
        {
            // Instantiate the explosion game object
            Instantiate(explosion, new Vector3(missileX, missileY, 0), Quaternion.Euler(0, 0, 0));

            // Destroy the game object collided with
            GameObject.Destroy(gameObject);

            // Destroy the game object itself
            GameObject.Destroy(this.gameObject);
        }

        // If the missile collided with the opponent, it will explode
        if (gameObject.CompareTag(opponentTag))
        {
            if (opponentTag == "Player1")
            {
                // Instantiate the explosion game object
                Instantiate(explosion, new Vector3(missileX, missileY, 0), Quaternion.Euler(0, 0, 0));

                // Decrement live from the player
                liveManagerPlayer1.decrementLive();

                // Destroy the game object itself
                GameObject.Destroy(this.gameObject);
            }
            else if (opponentTag == "Player2")
            {
                // Instantiate the explosion game object
                Instantiate(explosion, new Vector3(missileX, missileY, 0), Quaternion.Euler(0, 0, 0));

                // Decrement live from the player
                liveManagerPlayer2.decrementLive();

                // Destroy the game object itself
                GameObject.Destroy(this.gameObject);
            }
        }

        // If the missile collided with the wall, it will explode
        if (gameObject.CompareTag("wall"))
        {
            // Instantiate the explosion game object
            Instantiate(explosion, new Vector3(missileX, missileY, 0), Quaternion.Euler(0, 0, 0));

            // Destroy the game object itself
            GameObject.Destroy(this.gameObject);
        }

        // If the missile collided with the rock, it will explode
        if (gameObject.CompareTag("rock"))
        {
            // Instantiate the explosion game object
            Instantiate(explosion, new Vector3(missileX, missileY, 0), Quaternion.Euler(0, 0, 0));

            // Destroy the game object itself
            GameObject.Destroy(this.gameObject);
        }
    }
}
