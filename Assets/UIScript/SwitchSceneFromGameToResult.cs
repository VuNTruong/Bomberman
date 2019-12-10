using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneFromGameToResult : MonoBehaviour
{
    // Animator component of the object
    Animator anim;

    // Public access to the AudioSource element of the object
    public AudioSource audioSource;

    // Number of frame to wait until animation ends
    int numOfFrameToWait = 100;

    // public access to the IsAliveManger object
    public IsAliveManager isAliveManager;

    // boolean value to check if the game is over or not
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component of the object
        anim = GetComponent<Animator>();

        // Initially, game over value is false
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If one of the player dies, fade out and end the game
        if (!isAliveManager.getStatus())
        {
            // Fade out
            anim.SetBool("fadeout", true);

            // Set the game over value to true
            gameOver = true;
        } 

        // If the game is over, start switching scene
        if (gameOver)
        {
            // Turn the music off
            audioSource.Stop();

            // Decrease the number of frame to wait
            numOfFrameToWait -= 1;

            // If the number of frame to wait reaches 0, switch the scene
            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
