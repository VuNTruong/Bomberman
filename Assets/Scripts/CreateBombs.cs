using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBombs : MonoBehaviour
{
    // Reference to GameObject that will be dragged into inspector
    public GameObject thing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Get reference to the game object tagged "Player"
            GameObject gameObject = GameObject.FindWithTag("Player");

            // Get its Rigidbody2D and location
            Rigidbody2D player = gameObject.GetComponent<Rigidbody2D>();

            float playerX = player.position.x;
            float playerY = player.position.y;

            // The bomb shouldn't be placed in these following position
            // (12.5, 4.5)
            // (-12.5, -5.5)
            // (13.5, -5.5)
            // (13.5, 4.5)

            if ((playerX < -11.5 && playerY > 3.5) ||
                (playerX < -11.5 && playerY < -4.5) ||
                (playerX > 12.5 && playerY < -4.5) ||
                (playerX > 12.5 && playerY > 3.5))
            {
                return;
            }
            else
            {
                // Only instatiate the bomb if the player is not in those location
                Instantiate(thing, new Vector3(playerX, playerY, 0), Quaternion.identity);
            }
        }
    }
}
