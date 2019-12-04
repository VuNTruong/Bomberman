using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Number of frame for count down
    public int numOfFrame = 75;

    // Game object for the explosion
    public GameObject explosion4Ways;
    public GameObject explosionHorizontal;
    public GameObject explosionVertical;

    // Position of the bomb
    float bombX = 0f;
    float bombY = 0f;

    // ArrayList to contain position for the allowed x coordinate
    float [] allowedXCoordinate = new float[13];

    // ArrayList to contain position for the allowed y coordinate
    float[] allowedYCoordinate = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        bombX = this.transform.position.x;
        bombY = this.transform.position.y;

        // Add the allowed x coordinate to the array
        // aka the x coordinate of the point where the bomb should be able to explode
        // in 4 ways

        allowedXCoordinate[0] = -11.5f;
        allowedXCoordinate[1] = -9.5f;
        allowedXCoordinate[2] = -7.5f;
        allowedXCoordinate[3] = -5.5f;
        allowedXCoordinate[4] = -3.5f;
        allowedXCoordinate[5] = -1.5f;
        allowedXCoordinate[6] = 0.5f;
        allowedXCoordinate[7] = 2.5f;
        allowedXCoordinate[8] = 4.5f;
        allowedXCoordinate[9] = 6.5f;
        allowedXCoordinate[10] = 8.5f;
        allowedXCoordinate[11] = 10.5f;
        allowedXCoordinate[12] = 12.5f;

        // Add the allowed y coordinate to the array
        // aka the y coordinate of the point where the bomb should be able to explode
        // in 4 ways

        allowedYCoordinate[0] = 3.5f;
        allowedYCoordinate[1] = 1.5f;
        allowedYCoordinate[2] = -0.5f;
        allowedYCoordinate[3] = -2.5f;
        allowedYCoordinate[4] = -4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // If the number of frame reaches 0, destroy the object itself
        // aka the bomb
        if (numOfFrame == 0)
        {
            if (bombY > 4.3)
            {
                Instantiate(explosionHorizontal, new Vector3(bombX, bombY, 0), Quaternion.Euler(0, 0, 0));
                Debug.Log("Horizontal");
            }
            else if (bombX < -12.2)
            {
                Instantiate(explosionVertical, new Vector3(bombX, bombY, 0), Quaternion.Euler(0, 0, 0));
                Debug.Log("Vertical");
            }
            else
            {
                //Debug.Log("Bomb X " + bombX);
                //Debug.Log("Allowed X coordinate " + allowedXCoordinate[1]);
                // The loop run to determine wether to make the bomb explode 4 ways or not
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        // To determine the interval of x where the bomb is placed
                        if (allowedXCoordinate[i] <= bombX && allowedXCoordinate[i] + 2f >= bombX
                            && allowedYCoordinate[j] <= bombY && allowedYCoordinate[j] + 2f >= bombY)
                        {
                            // And then to determine if the bomb should explode 4 ways or not
                            // 4 ways explosion should only be instantiate if the bomb is placed
                            // more than 0.6f away from the rock
                            if (allowedXCoordinate[i] + 0.6f < bombX && allowedXCoordinate[i] + 1.4f > bombX
                                && allowedYCoordinate[j] + 0.6f < bombY && allowedYCoordinate[j] + 1.4f > bombY)
                            {
                                // Instantiate the explosion game object
                                Instantiate(explosion4Ways, new Vector3(bombX, bombY, 0), Quaternion.Euler(0, 0, 0));
                            }

                            // Instantiate the horizontal explosion
                            // If the bomb is placed less than 0.6f away from the rock in the 
                            // horizontal direction, only the horizontal explosion should be
                            // instantiate
                            else if (allowedXCoordinate[i] + 0.6f > bombX || allowedXCoordinate[i] + 1.4f < bombX)
                            {
                                // Otherwise, just instantiate the horizontal explosion
                                Instantiate(explosionHorizontal, new Vector3(bombX, bombY, 0), Quaternion.Euler(0, 0, 0));
                            }

                            // Instantiate the vertical explosion
                            // If the bomb is placed less than 0.06f away from the rock in the
                            // vertical direction, only the vertical explosion should be
                            // instantiate
                            else if (allowedYCoordinate[j] + 0.6f > bombY || allowedYCoordinate[j] + 1.4f < bombY)
                            {
                                // Otherwise, just instantiate the vertical explosion
                                Instantiate(explosionVertical, new Vector3(bombX, bombY, 0), Quaternion.Euler(0, 0, 0));
                            }
                        }
                    }
                }
            }

            // Destroy the object
            GameObject.Destroy(this.gameObject);
        }

        // Decrement the frame number 
        numOfFrame -= 1;
    }
}
