using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    // Reference to GameObject that will be dragged into inspector
    public GameObject thing;

    // Number of frame to instantiate
    public int numOfFrame = 500;

    // Array of positions not to instantiate the HP
    ArrayList positionToCreate = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                positionToCreate.Add(new Vector3(-12.5f + 2 * i, 4.5f - 2 * j, 0f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        numOfFrame -= 1;

        if (numOfFrame == 0)
        {
            // Position to instantiate
            Vector3 position = (Vector3)positionToCreate[Random.Range(0, 70)];

            // Instantiate
            Instantiate(thing, position, Quaternion.Euler(0, 0, 0));

            numOfFrame = 500;
        }
    }
}
