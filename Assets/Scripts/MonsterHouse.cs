using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHouse : MonoBehaviour
{
    // Number of frame to instantiate monster
    public int numOfFrame = 100;

    // Monster game object to instantiate
    public GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the numeber of frame every frame count
        numOfFrame -= 1;

        if (numOfFrame == 0)
        {
            // Instantiate the monster
            Instantiate(monster, transform.position, transform.rotation);

            // Bring the number of frame back to 100
            numOfFrame = 500;
        }
    }
}
