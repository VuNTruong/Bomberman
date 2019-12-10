using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    // Reference to GameObject that will be dragged into inspector
    public GameObject thing;

    // Number of frame to instantiate
    public int numOfFrame = 500;

    // AudioSource component of the object
    AudioSource audioSource;

    // ArrayList of position of where to launch the missile
    ArrayList positionToLaunch = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        // Add Vector3 objects of positions to launch the missile
        positionToLaunch.Add(new Vector3(-12.5f + 1.3f, 4.5f, 0f));
        positionToLaunch.Add(new Vector3(-12.5f + 1.3f, 2.5f, 0f));
        positionToLaunch.Add(new Vector3(-12.5f + 1.3f, 0.5f, 0f));
        positionToLaunch.Add(new Vector3(-12.5f + 1.3f, -1.5f, 0f));
        positionToLaunch.Add(new Vector3(-12.5f + 1.3f, -3.5f, 0f));
        positionToLaunch.Add(new Vector3(-12.5f + 1.3f, -5.5f, 0f));

        // Get the AudioSource component of the object
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        numOfFrame -= 1;

        if (numOfFrame == 150)
        {
            audioSource.Play();
        }

        if (numOfFrame == 0)
        {
            // Position to instantiate
            Vector3 position = (Vector3)positionToLaunch[Random.Range(0, 5)];

            // Instantiate
            Instantiate(thing, position, Quaternion.Euler(0, 0, 0));

            numOfFrame = 500;

            audioSource.Stop();
        }
    }
}
