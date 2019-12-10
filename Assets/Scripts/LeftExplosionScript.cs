using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftExplosionScript : MonoBehaviour
{
    // Number of frame for count down
    public int numOfFrame = 100;

    // Number of frame decrease live
    public int numOfFrameDecreaseLive = 10;

    // Collider for this game object
    Collider2D thisCollider;

    // Collider for the enemy game object
    Collider2D enemyCollider;

    // Game object for the enemy
    GameObject enemy;

    // public access to the ScoreManager of the 2 players
    // so that knows which player to add score to
    public ScoreManagerPlayer1 scoreManagerPlayer1;
    public ScoreManagerPlayer2 scoreManagerPlayer2;

    // public access to the LiveManager of the 2 players
    // so that knows which player to decrease live from
    public LivesManager livesManagerPlayer1;
    public LivesManagerPlayer2 livesManagerPlayer2;

    // public access to the BombAndExplosion object so as to interact with the bomb
    public BombAndExplosion bombAndExplosion;

    // Start is called before the first frame update
    void Start()
    {
        // Find the game object for the enemy
        GameObject gameObject = GameObject.FindWithTag("monster");
        enemy = gameObject;

        // Get the collider for the enemy
        enemyCollider = gameObject.GetComponent<Collider2D>();

        // Get the collider for this game object 
        thisCollider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find which monster enters the explosion
        FindMonsterEnter();

        // If the number of frame reaches 0, destroy the object itself
        // aka the explosion
        if (numOfFrame == 0)
        {
            // Destroy the object
            GameObject.Destroy(this.gameObject);
        }

        // Decrement the frame number
        numOfFrame -= 1;
    }

    public void FindMonsterEnter()
    {
        // Array for game objects with tag "monster"
        GameObject[] gos;

        // Find all objects with tag "Player" and put into an array
        gos = GameObject.FindGameObjectsWithTag("monster");

        Debug.Log(gos.Length);

        // Loop runs to determine which monster encounter the explosion
        foreach (GameObject go in gos)
        {
            // Get the collider of the object
            Collider2D collider2D = go.GetComponent<Collider2D>();

            if (thisCollider.bounds.Intersects(collider2D.bounds))
            { 
                // Destroy the monster if it enters the explosion
                Destroy(go.gameObject);

                // Increase the score for the player who kill the monster
                if (bombAndExplosion.getOwner() == "Player1")
                {
                    scoreManagerPlayer1.incrementScore(10);
                }
                if (bombAndExplosion.getOwner() == "Player2")
                {
                    scoreManagerPlayer2.incrementScore(10);
                }
            }
        }

        // Get reference to player 1
        GameObject player1GameObject = GameObject.FindWithTag("Player1");

        // Get reference to player 2
        GameObject player2GameObject = GameObject.FindWithTag("Player2");

        // Get the Collider2D component of player 1
        Collider2D player1Collider2D = player1GameObject.GetComponent<Collider2D>();

        // Get the Collider2D component of player 2
        Collider2D player2Collider2D = player2GameObject.GetComponent<Collider2D>();

        // Check if player 1 enters the explosion or not
        if (thisCollider.bounds.Intersects(player1Collider2D.bounds))
        {
            // Decrease the number of frame to decrease live by 1
            numOfFrameDecreaseLive -= 1;

            // If the number of frame to decrease live is 0, decrease the
            // live of the player and set the number of frame back to 10
            if (numOfFrameDecreaseLive == 0)
            {
                // Decrement the number of frame by 1
                livesManagerPlayer1.decrementLive();

                // Bring the number of frame back to 10
                numOfFrameDecreaseLive = 10;
            }
        }

        // Check if player 2 enters the explosion or not
        if (thisCollider.bounds.Intersects(player2Collider2D.bounds))
        {
            // Decrease the number of frame to decrease live by 1
            numOfFrameDecreaseLive -= 1;

            // If the number of frame to decrease live is 0, decrease the
            // live of the player and set the number of frame back to 10
            if (numOfFrameDecreaseLive == 0)
            {
                // Decrement the number of frame by 1
                livesManagerPlayer2.decrementLive();

                // Bring the numebr of frame back to 10
                numOfFrameDecreaseLive = 10;    
            }
        }
    }
}
