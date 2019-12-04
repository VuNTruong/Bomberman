using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftExplosionScript : MonoBehaviour
{
    // Number of frame for count down
    public int numOfFrame = 25;

    // Collider for this game object
    Collider2D thisCollider;

    // Collider for the enemy game object
    Collider2D enemyCollider;

    // Game object for the enemy
    GameObject enemy;

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
                Debug.Log("On collison stay");

                Destroy(go.gameObject);
            }
        }
    }
}
