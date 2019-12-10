using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Simple demonstration of scene management. 
// We assume this script is attached to an object in some opening "splash screen" scene,
// and the user has been prompted to press the "s" key to start the game.
public class SwitchSceneFromSpashToWelcome : MonoBehaviour
{
    // Number of frame to stay in splash screen
    public int numOfFrame = 50;

    // Animation component of the object
    public Animator anim;

    // boolean value to check if the scence is switching or not
    bool isSwitching = false;

    // Number of frame to wait until the animation is done
    int numOfFrameToWait = 150;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("fadeout", false);
    }

    // Update is called once per frame
    void Update()
    {
        numOfFrame -= 1;

        if (numOfFrame == 0)
        {
            // Fade out the spash screen
            anim.SetBool("fadeout", true);

            // Start switching
            isSwitching = true;
        }

        if (isSwitching)
        {
            // Decrease the number of wait frame by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
