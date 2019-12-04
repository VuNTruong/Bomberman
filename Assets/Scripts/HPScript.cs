using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    // Number of frame to stay on screen
    public int numOfFrame = 250;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the number of frame
        numOfFrame -= 1;

        // If the number of frame is 0, destroy the object
        if (numOfFrame == 0)
        {
            // Destroy the game object itself
            Destroy(this.gameObject);
        }
    }
}
